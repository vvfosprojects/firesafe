using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence.MongoDB
{
    internal class GetProdottoByCodice : IGetProdottoByCodice
    {
        private readonly DbContext dbContext;

        public GetProdottoByCodice(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Prodotto Get(string codice)
        {
            return this.dbContext.ProdottiCollection.Find(p => p.Prog == codice).Single();
        }
    }
}
