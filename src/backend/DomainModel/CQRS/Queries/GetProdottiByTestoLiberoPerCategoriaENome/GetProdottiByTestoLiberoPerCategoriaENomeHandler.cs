using CQRS.Queries;
using DomainModel.Services;
using System;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome
{
    public class GetProdottiByTestoLiberoPerCategoriaENomeHandler : IQueryHandler<GetProdottiByTestoLiberoPerCategoriaENomeQuery, GetProdottiByTestoLiberoPerCategoriaENomeQueryResult>
    {
        private readonly IGetProdottiByTestoLiberoPerCategoriaENome getProdottiByTestoLiberoPerCategoriaENome;

        public GetProdottiByTestoLiberoPerCategoriaENomeHandler(IGetProdottiByTestoLiberoPerCategoriaENome getProdottiByTestoLiberoPerCategoriaENome)
        {
            this.getProdottiByTestoLiberoPerCategoriaENome = getProdottiByTestoLiberoPerCategoriaENome ?? throw new ArgumentNullException(nameof(getProdottiByTestoLiberoPerCategoriaENome));
        }

        public GetProdottiByTestoLiberoPerCategoriaENomeQueryResult Handle(GetProdottiByTestoLiberoPerCategoriaENomeQuery query)
        {
            /*
             * La dimensione massima dell'array di Prodotti in risposta deve essere
             * minore o uguale a 20.
            */
            if (query.PageSize > 20)
            {
                query.PageSize = 20;
            }

            // La pagina deve essere almeno pari ad 1
            if (query.Page < 1)
            {
                query.Page = 1;
            }

            return new GetProdottiByTestoLiberoPerCategoriaENomeQueryResult()
            {
                Criteri = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).Criteri,
                FacetCategorie = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).FacetCategorie,
                FacetAnnoFirmaConvenzione = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).FacetAnnoFirmaConvenzione,
                FacetAnnoScadenzaConvenzione = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).FacetAnnoScadenzaConvenzione,
                Prodotti = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).Prodotti,
                Risultati = this.getProdottiByTestoLiberoPerCategoriaENome.Get(query).Risultati
            };
        }           
    }
}
