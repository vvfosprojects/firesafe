using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CompositionRoot")]

namespace Persistence.InMemory
{
    class GetProdottoByCodice : IGetProdottoByCodice
    {
        private readonly Database database;

        public GetProdottoByCodice(Database database)
        {
            this.database = database;
        }

        public Prodotto Get(string codice)
        {
            return this.database.Prodotti.Single(p => p.Prog == codice);
        }
    }
}
