using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.InMemory
{
    internal class GetProdottiByTestoLiberoPerCategoriaENome : IGetProdottiByTestoLiberoPerCategoriaENome
    {
        private readonly Database_hardcoded database;

        public GetProdottiByTestoLiberoPerCategoriaENome(Database_hardcoded database)
        {
            this.database = database;
        }

        /// <summary>
        /// La ricerca viene effettuata su tutti i prodotti applicando la seguente logica:
        /// PRIMO FILTRO: categoria
        /// SECONDO FILTRO: annoFirma
        /// TERZO FILTRO: annoScadenzaFirma
        /// QUARTO FILTRO: ricerca full-text DenominazioneProdotto
        /// </summary>
        /// <param name="query">DTO di input</param>
        /// <returns>Elenco di prodotti che corrispondono ai filtri inseriti</returns>
        public GetProdottiByTestoLiberoPerCategoriaENomeQueryResult Get(GetProdottiByTestoLiberoPerCategoriaENomeQuery query)
        {
            //carico il db
            var prodotti = this.database.Prodotti;

            //filtro i prodotti per chiave e categoria
            var prodottiConPunteggio = prodotti.Select(p => new
            {
                p = p,
                score = p.ScoreByNameSeachKey(query.Key) //+  p.ScoreByCategorySearchKey(query.Categorie) 
            });

            //var punteggio = 0;

            //if (string.IsNullOrWhiteSpace(query.Key) && query.Categorie.Any() && query.Categorie.First() == null) punteggio = 0;
            //if (string.IsNullOrWhiteSpace(query.Key) && query.Categorie.Any() && query.Categorie.First() != null) punteggio = 0;

            /*
              * viene costruito un array prodottiCheMatchanoOrdinati il quale è composto da tutti i prodotti in
              * prodottiConPunteggio che hanno uno score > 1 (quindi c'è stato un match almeno parziale con la key)
              * e successivamente l'array viene ordinato per Progressivo
              */
            var prodottiCheMatchanoOrdinati = prodottiConPunteggio
                .Where(p => p.score > 0)
                .OrderByDescending(p => p.score)
                .ThenByDescending(p => p.p.Prog)
                .Select(pp => pp.p)
                .ToList();


            //=========================================================================

            /*  se la chiave è null e la categoria è null non sto applicando nessun filtro 
             *  quindi ritorno l'intero db, le la chiave è null devo comunque ritornare in questo punto l'intero db
            */
            if (string.IsNullOrWhiteSpace(query.Key) && query.Categorie == null || string.IsNullOrWhiteSpace(query.Key))
            {
                prodottiCheMatchanoOrdinati = prodotti;
            }


            //==========================================================================

            ////qualora la chiave fosse vuota, l'array prodottiCheMatchanoOrdinati sarebbe vuoto dunque prendo in considerazione l'intero db
            //if (!prodottiCheMatchanoOrdinati.Any())
            //{
            //    prodottiCheMatchanoOrdinati = prodotti;
            //}

            //facetCategoria
            var facetCategoria = prodottiCheMatchanoOrdinati.GroupBy(p => p.MacroGruppo)
                                                .Select(g => new Facet()
                                                {
                                                    Cat = g.Key,
                                                    Count = g.Count()
                                                }).OrderByDescending(f => f.Count);



            var prodottiFiltratiPerCategoria = prodottiCheMatchanoOrdinati;

            //filtra tutti i prodotti che hanno avuto un matching con la key, per categorie, se presenti
            //var prodottiFiltratiPerCategoria = new List<Prodotto>();

            if (query.Categorie != null)
            {
                prodottiFiltratiPerCategoria = prodottiCheMatchanoOrdinati
                .Where(p => query.Categorie.Contains(p.MacroGruppo)).ToList();
            }

            var prodottiFiltratiPerCategoriaBeforeFiltring = prodottiFiltratiPerCategoria;

            /*
       * Costruzione della Facet anno di firma 
       */
            var prodottiPerAnnoFirmaConvenzione = prodottiFiltratiPerCategoria
                 .GroupBy(pc => pc.Firma.Year)
                 .Select(pf => new FacetAnnoFirmaConvenzione()
                 {
                     Anno = pf.Key,
                     Count = pf.Count()
                 })
                 .OrderByDescending(z => z.Anno);

            /*
             * Costruzione della Facet anno di scadenza
             */
            var prodottiPerAnnoScadenzaConvenzione = prodottiFiltratiPerCategoria
                .GroupBy(pc => pc.Scadenza.Year)
                .Select(pf => new FacetAnnoScadenzaConvenzione()
                {
                    Anno = pf.Key,
                    Count = pf.Count()
                })
                .OrderByDescending(z => z.Anno);

            var prodottiFiltratiPerCategoriaEAnnoFirma = new List<Prodotto>();
            var prodottiFiltratiPerCategoriaEAnnoScadenzaFirma = new List<Prodotto>();

            /*
             * se presente il filtro su AnnoFirma, filtro i prodotti che matchano esattamente sull'anno selezionato
             */
            if (query.AnnoFirmaConvenzione != null)
            {
                foreach (int anno in query.AnnoFirmaConvenzione)
                {
                    var prdFiltratiCategoriaAnnoFirma = prodottiFiltratiPerCategoria.Where(p => p.Firma.Year == anno);
                    prodottiFiltratiPerCategoriaEAnnoFirma = prodottiFiltratiPerCategoriaEAnnoFirma.Concat(prdFiltratiCategoriaAnnoFirma).ToList();
                }
            }
            else
            {
                prodottiFiltratiPerCategoriaEAnnoFirma = prodottiFiltratiPerCategoria;
            }

            /*
             * se presente il filtro su AnnoScadenzaFirma, filtro i prodotti che matchano esattamente sull'anno selezionato
             */
            if (query.AnnoScadenzaConvenzione != null)
            {
                foreach (int anno in query.AnnoScadenzaConvenzione)
                {
                    var pdrFiltratiCategoriaAnnoFirmaAnnoScadenzaFirma = prodottiFiltratiPerCategoria.Where(p => p.Scadenza.Year == anno).ToList();
                    prodottiFiltratiPerCategoriaEAnnoScadenzaFirma = prodottiFiltratiPerCategoriaEAnnoScadenzaFirma.Concat(pdrFiltratiCategoriaAnnoFirmaAnnoScadenzaFirma).ToList();
                }
            }
            else
            {
                prodottiFiltratiPerCategoriaEAnnoScadenzaFirma = prodottiFiltratiPerCategoriaEAnnoFirma;
            }

            prodottiFiltratiPerCategoria = prodottiFiltratiPerCategoriaEAnnoScadenzaFirma.Concat(prodottiFiltratiPerCategoriaEAnnoFirma).Distinct().ToList();

            
            /*
             * se prodottiFiltratiPerCategoria è vuoto (dunque non è stata immessa nessuna categoria in input o non 
             * sono state trovate occorrenze) allora prodottiFiltratiPerCategoria conterrà tutti i prodotti del db
             */
            //if (prodottiCheMatchanoOrdinati.Any() == false && string.IsNullOrWhiteSpace(query.Key))
            //{
            //    prodottiFiltratiPerCategoria = prodottiCheMatchanoOrdinati;
            //}

       
            if (!prodottiFiltratiPerCategoria.Any())
            {
                prodottiFiltratiPerCategoria = prodottiFiltratiPerCategoriaBeforeFiltring;
            }

            


            /*
             * Viene creata la paginazione
             */
            var paginaProdotti = prodottiFiltratiPerCategoria
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);

            /*
             * Costruzione del DTO di output
             */
            return new GetProdottiByTestoLiberoPerCategoriaENomeQueryResult()
            {
                Criteri = new CriteriRicerca()
                {
                    Key = query.Key,
                    Categorie = query.Categorie,
                    PageSize = query.PageSize,
                    Page = query.Page,
                    AnnoFirmaConvenzione = query.AnnoFirmaConvenzione,
                    AnnoScadenzaConvenzione = query.AnnoScadenzaConvenzione
                },
                FacetCategorie = facetCategoria.ToArray(),
                FacetAnnoFirmaConvenzione = prodottiPerAnnoFirmaConvenzione.ToArray(),
                FacetAnnoScadenzaConvenzione = prodottiPerAnnoScadenzaConvenzione.ToArray(),
                Prodotti = paginaProdotti.ToArray(),
                Risultati = new RisultatiRicerca()
                {
                    Totale = prodotti.Count(),
                    Filtrati = prodottiFiltratiPerCategoria.Count(),
                    FirstIndex = (query.Page - 1) * query.PageSize,
                    LastIndex = ((query.Page - 1) * query.PageSize) + query.PageSize - 1
                }
            };
        }
    }
}
