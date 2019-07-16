using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence.InMemory
{
    internal class GetProdottoByCodice : IGetProdottoByCodice
    {
        private readonly Database database;

        public GetProdottoByCodice(Database database)
        {
            this.database = database;
        }

        public Prodotto Get(string codice)
        {
            return this.database.Prodotti.FirstOrDefault(p => p.Prog == codice);
        }
    }
}
