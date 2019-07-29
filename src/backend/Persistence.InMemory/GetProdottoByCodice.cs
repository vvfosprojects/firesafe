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
        private readonly Database_hardcoded database;

        public GetProdottoByCodice(Database_hardcoded database)
        {
            this.database = database;
        }

        /// <summary>
        ///   Ritorna il singolo prodotto, ricercato per codice, se presente.
        /// </summary>
        /// <param name="codice">Rappresenta il codice di un prodotto da ricercare</param>
        /// <returns></returns>
        public Prodotto Get(string codice)
        {
            return this.database.Prodotti.Single(p => p.Prog == codice);
        }
    }
}
