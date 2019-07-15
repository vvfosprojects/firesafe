using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.Services;
using System;

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
            throw new System.NotImplementedException();
        }
    }
}
