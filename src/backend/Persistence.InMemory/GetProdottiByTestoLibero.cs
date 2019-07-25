﻿using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.Services;
using System;
using System.Collections.Generic;
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
                .OrderByDescending(p => p.score).ThenByDescending(p => Int32.Parse(p.p.Prog));

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

            var prodottiPerAnnoFirmaConvenzione = prodottiCheMatchanoOrdinati
                .GroupBy(pc => pc.p.Firma.Year)
                .Select(pf => new FacetAnnoFirmaConvenzione()
                {
                    Anno = pf.Key,
                    Count = pf.Count()
                })
                .OrderByDescending(z => z.Anno);

            var prodottiPerAnnoScadenzaConvenzione = prodottiCheMatchanoOrdinati
                .GroupBy(pc => pc.p.Scadenza.Year)
                .Select(pf => new FacetAnnoScadenzaConvenzione()
                {
                    Anno = pf.Key,
                    Count = pf.Count()
                })
                .OrderByDescending(z => z.Anno);

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
