using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class GetProdottiByTestoLiberoHandler : IQueryHandler<GetProdottiByTestoLiberoQuery, GetProdottiByTestoLiberoQueryResult>
    {
        private readonly IGetProdottiByTestoLibero getProdottiByTestoLibero;

        public GetProdottiByTestoLiberoHandler(IGetProdottiByTestoLibero getProdottiByTestoLibero)
        {
            this.getProdottiByTestoLibero = getProdottiByTestoLibero ?? throw new ArgumentNullException(nameof(getProdottiByTestoLibero));
        }

        public GetProdottiByTestoLiberoQueryResult Handle(GetProdottiByTestoLiberoQuery query)
        {
            /*
             * La dimensione massima dell'array di Prodotti in risposta deve essere
             * minore o uguale a 20.
            */
            if (query.PageSize > 20)
            {
                query.PageSize = 20;
            }

            return new GetProdottiByTestoLiberoQueryResult()
            {
                Criteri = this.getProdottiByTestoLibero.Get(query).Criteri,
                FacetCategorie = this.getProdottiByTestoLibero.Get(query).FacetCategorie,
                FacetAnnoFirmaConvenzione = this.getProdottiByTestoLibero.Get(query).FacetAnnoFirmaConvenzione,
                FacetAnnoScadenzaConvenzione = this.getProdottiByTestoLibero.Get(query).FacetAnnoScadenzaConvenzione,
                Prodotti = this.getProdottiByTestoLibero.Get(query).Prodotti,
                Risultati = this.getProdottiByTestoLibero.Get(query).Risultati
            };
        }
    }
}
