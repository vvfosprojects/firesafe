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
            return new GetProdottiByTestoLiberoQueryResult()
            {
                Criteri = this.getProdottiByTestoLibero.Get(query).Criteri,
                FacetCategorie = this.getProdottiByTestoLibero.Get(query).FacetCategorie,
                FacetAnnoFirmaConvenzione = this.getProdottiByTestoLibero.Get(query).FacetAnnoFirmaConvenzione,
                Prodotti = this.getProdottiByTestoLibero.Get(query).Prodotti,
                Risultati = this.getProdottiByTestoLibero.Get(query).Risultati
            };
        }
    }
}
