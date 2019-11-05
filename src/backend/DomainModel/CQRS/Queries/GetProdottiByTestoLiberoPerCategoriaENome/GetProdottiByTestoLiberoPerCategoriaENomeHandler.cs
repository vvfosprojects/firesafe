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
            throw new NotImplementedException();
        }           
    }
}
