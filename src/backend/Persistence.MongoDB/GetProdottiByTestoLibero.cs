using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.MongoDB
{
    internal class GetProdottiByTestoLibero : IGetProdottiByTestoLibero
    {
        private readonly DbContext dbContext;

        public GetProdottiByTestoLibero(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public GetProdottiByTestoLiberoQueryResult Get(GetProdottiByTestoLiberoQuery query)
        {
            //creo un array di chiavi dal DTO di input
            string[] keys = query.Key.Split(" ");

            Dictionary<string, ProdottoConScore> final = new Dictionary<string, ProdottoConScore>();
            List<Prodotto> matchDenominazione = new List<Prodotto>();
            List<Prodotto> matchDenominazione1 = new List<Prodotto>();

            List<Prodotto> matchImpiegoMacroGruppo = new List<Prodotto>();
            List<Prodotto> containsDenominazione = new List<Prodotto>();
            List<Prodotto> containsImpiegoMacroGruppo = new List<Prodotto>();
            List<ProdottoConScore> prodottoConScoreFinale = new List<ProdottoConScore>();

            var collection = dbContext.ProdottiCollection;
            //collection.Indexes.CreateOne(Builders<Prodotto>.IndexKeys.Text(p => p.MacroGruppo));

            //var coll = collection.Find(Builders<Prodotto>.Filter.Text("SEDIE")).ToList();

            foreach (string key in keys)
            {
                // contiene tutti i prodotti che matchano esattamente in DenominazioneCommerciale con
                // la chiave
                matchDenominazione = collection.Find(x => x.DenominazioneCommerciale.ToLower() == key.ToLower()).ToList();

                // contiene tutti i prodotti che matchano esattamente in Impiego o Macrogruppo con la chiave
                matchImpiegoMacroGruppo = collection.Find(x => x.Impiego.ToLower() == key.ToLower() ||
                                                          x.MacroGruppo.ToLower() == key.ToLower()).ToList();

                // contiene tutti i prodotti che contengono in DenominazioneCommerciale la chiave
                containsDenominazione = collection.Find(x => x.DenominazioneCommerciale.ToLower().Contains(key.ToLower())).ToList();

                // contiene tutti i prodotti che contengono in Impiego o MacroGruppo la chiave
                containsImpiegoMacroGruppo = collection.Find(x => x.Impiego.ToLower().Contains(key.ToLower()) ||
                                                            x.MacroGruppo.Contains(key.ToLower())).ToList();

                //aggiungo al dizionario tutti i prodotti contenuti in containsDenominazione
                foreach (Prodotto prod in containsDenominazione)
                {
                    final.Add(prod.Id, new ProdottoConScore(prod, 1));
                }

                foreach (Prodotto prod in matchDenominazione)
                {
                    //se il dizionario non contiene l'elemento
                    if (final.ContainsKey(prod.Id) == false)
                    {
                        //lo aggiungo assegnando peso 2, poichè MATCHA esattamente con DenominazioneProdotto
                        final.Add(prod.Id, new ProdottoConScore(prod, 2));
                    }
                    else
                    {
                        /*
                         * altrimenti se è già presente (quindi si trovava in containsDenominazione) devo aggiornare il suo score,
                         * aggiungendo peso +2
                        */
                        final[prod.Id].score += 2;
                    }
                }

                foreach (Prodotto prod in containsImpiegoMacroGruppo)
                {
                    //se il dizionario non contiene l'elemento
                    if (final.ContainsKey(prod.Id) == false)
                    {
                        //lo aggiungo assegnando peso 1, poichè la chiave è CONTENUTA in Impiego o MacroGruppo
                        final.Add(prod.Id, new ProdottoConScore(prod, 1));
                    }
                    else
                    {
                        /*
                         * altrimenti se è già presente, devo aggiornare il suo score, aggiungendo peso +1
                        */
                        final[prod.Id].score += 1;
                    }
                }

                foreach (Prodotto prod in matchImpiegoMacroGruppo)
                {
                    //se il dizionario non contiene l'elemento
                    if (final.ContainsKey(prod.Id) == false)
                    {
                        //lo aggiungo assegnando peso 2, poichè MATCHA esattamente con Impiego o MacroGruppo
                        final.Add(prod.Id, new ProdottoConScore(prod, 2));
                    }
                    else
                    {
                        /*
                         * altrimenti se è gia presente, devo aggiornare il suo score, aggiungendo peso +2
                         */
                        final[prod.Id].score += 2;
                    }
                }

                //svuoto le liste
                matchDenominazione = null;
                matchImpiegoMacroGruppo = null;
                containsImpiegoMacroGruppo = null;
                containsDenominazione = null;
            }

            //recupero (solo) i valori dal dizionario
            foreach (ProdottoConScore prodScore in final.Values)
            {
                prodottoConScoreFinale.Add(prodScore);
            }

            var prodottiCheMatchanoOrdinati = prodottoConScoreFinale.OrderByDescending(p => p.score);

            /*
             * La dimensione massima dell'array di Prodotti in risposta deve essere
             * minore o uguale a 20.
            */
            if (query.PageSize > 20)
            {
                query.PageSize = 20;
            }

            var paginaProdotti = prodottiCheMatchanoOrdinati
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);

            var prodottiPerCategoria = prodottiCheMatchanoOrdinati
                .GroupBy(pp => pp.prodotto.MacroGruppo)
                .Select(g => new Facet()
                {
                    Cat = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(f => f.Count);

            return new GetProdottiByTestoLiberoQueryResult()
            {
                Criteri = new CriteriRicerca()
                {
                    Key = query.Key,
                    Categorie = query.Categorie,
                    PageSize = query.PageSize,
                    Page = query.Page
                },
                FacetCategorie = prodottiPerCategoria.ToArray(),
                Prodotti = paginaProdotti
                  .Select(pp => pp.prodotto)
                  .ToArray(),
                Risultati = new RisultatiRicerca()
                {
                    Totale = (int)collection.CountDocuments(new BsonDocument()),
                    Filtrati = prodottiCheMatchanoOrdinati.Count(),
                    FirstIndex = (query.Page - 1) * query.PageSize,
                    LastIndex = ((query.Page - 1) * query.PageSize) + query.PageSize
                }
            };
        }
    }
}
