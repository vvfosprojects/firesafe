using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.Services;
using System;
using System.Linq;

namespace Persistence.InMemory
{
    internal class GetProdottiByTestoLibero : IGetProdottiByTestoLibero
    {
        private readonly Database_hardcoded database;

        public GetProdottiByTestoLibero(Database_hardcoded database)
        {
            this.database = database;
        }

        /// <summary>
        /// Ricerca full-text dei prodotti
        /// </summary>
        /// <param name="query">DTO di input</param>
        /// <returns></returns>
        public GetProdottiByTestoLiberoQueryResult Get(GetProdottiByTestoLiberoQuery query)
        {
            var prodotti = this.database.Prodotti;

            //filtra tutti i prodotti per categorie, se presenti
            var prodottiFiltratiPerCategoria = prodotti
                .Where(p => !query.Categorie.Any() || query.Categorie.Contains(p.MacroGruppo));


            /*
             * se prodottiFiltratiPerCategoria è vuoto (dunque non è stata immessa nessuna categoria in input o non 
             * sono state trovate occorrenze) allora prodottiFiltratiPerCategoria conterrà tutti i prodotti del db
             */
            if (prodottiFiltratiPerCategoria.Any() == false)
            {
                prodottiFiltratiPerCategoria = prodotti;
            }

            /*
             * viene costruito una classe anonima che conterrà un Prodotto e uno score associato il quale indicherà 
             * la pertinenza del prodotto rispetto alla/e parola/e chiave inserita/e
             */
            var prodottiConPunteggio = prodottiFiltratiPerCategoria.Select(p => new
            {
                p = p,
                score = p.ScoreByMultipleSearchKey(query.Key)
            });

            /*
             * viene costruito un array prodottiCheMatchanoOrdinati il quale è composto da tutti i prodotti in
             * prodottiConPunteggio che hanno uno score > 1 (quindi c'è stato un match almeno parziale con la key)
             * e successivamente l'array viene ordinato per Progressivo
             */
            var prodottiCheMatchanoOrdinati = prodottiConPunteggio
                .Where(p => p.score > 0)
                .OrderByDescending(p => p.score)
                .ThenByDescending(p => p.p.Prog);

            /*
             * Viene creata la paginazione
             */
            var paginaProdotti = prodottiCheMatchanoOrdinati
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize);

            /*
             * Costruzione della Facet categoria
             */
            var prodottiPerCategoria = prodottiCheMatchanoOrdinati
                .GroupBy(pp => pp.p.MacroGruppo)
                .Select(g => new Facet()
                {
                    Cat = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(f => f.Count);

            /*
             * Costruzione della Facet anno di firma 
             */
            var prodottiPerAnnoFirmaConvenzione = prodottiCheMatchanoOrdinati
                .GroupBy(pc => pc.p.Firma.Year)
                .Select(pf => new FacetAnnoFirmaConvenzione()
                {
                    Anno = pf.Key,
                    Count = pf.Count()
                })
                .OrderByDescending(z => z.Anno);

            /*
             * Costruzione della Facet anno di scadenza
             */
            var prodottiPerAnnoScadenzaConvenzione = prodottiCheMatchanoOrdinati
                .GroupBy(pc => pc.p.Scadenza.Year)
                .Select(pf => new FacetAnnoScadenzaConvenzione()
                {
                    Anno = pf.Key,
                    Count = pf.Count()
                })
                .OrderByDescending(z => z.Anno);

            /*
             * Costruzione del DTO di output
             */
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
                FacetAnnoFirmaConvenzione = prodottiPerAnnoFirmaConvenzione.ToArray(),
                FacetAnnoScadenzaConvenzione = prodottiPerAnnoScadenzaConvenzione.ToArray(),
                Prodotti = paginaProdotti
                  .Select(pp => pp.p)
                  .ToArray(),
                Risultati = new RisultatiRicerca()
                {
                    Totale = prodotti.Count(),
                    Filtrati = prodottiCheMatchanoOrdinati.Count(),
                    FirstIndex = (query.Page - 1) * query.PageSize,
                    LastIndex = ((query.Page - 1) * query.PageSize) + query.PageSize - 1
                }
            };
        }
    }
}
