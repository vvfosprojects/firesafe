using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.Services;
using System.Collections.Generic;
using System.Linq;

//anche se commentata la CompositionRoot riesce ad entrare nella classe... perchè? forse perchè già presente in GetProdottoByCodice?
//[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence.InMemory
{
    internal class GetProdottiByTestoLibero : IGetProdottiByTestoLibero
    {
        private readonly Database database;

        public GetProdottiByTestoLibero(Database database)
        {
            this.database = database;
        }

        public GetProdottiByTestoLiberoQueryResult Get(GetProdottiByTestoLiberoQuery query)
        {
            var prodotti = this.database.Prodotti;

            var prodottiConPunteggio = prodotti.Select(p => new
            {
                p = p,
                score = p.ScoreByMultipleSearchKey(query.Key)
            });

            var prodottiCheMatchanoOrdinati = prodottiConPunteggio
                .Where(p => p.score > 0)
                .OrderByDescending(p => p.score);

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
                .GroupBy(pp => pp.p.MacroGruppo)
                .Select(g => new Facet()
                {
                    Cat = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(f => f.Count);

            //aggiunto cast int
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
                  .Select(pp => pp.p)
                  .ToArray(),
                Risultati = new RisultatiRicerca()
                {
                    Totale = prodotti.Count(),
                    Filtrati = prodottiCheMatchanoOrdinati.Count(),
                    FirstIndex = (query.Page - 1) * query.PageSize,
                    LastIndex = ((query.Page - 1) * query.PageSize) + query.PageSize
                }
            };
        }
    }
}
