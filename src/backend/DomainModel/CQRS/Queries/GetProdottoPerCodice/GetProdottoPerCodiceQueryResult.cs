using DomainModel.Classes;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQueryResult
    {
        /// <summary>
        /// Rappresenta il prodotto trovato nella ricerca per codice
        /// </summary>
        public Prodotto Prodotto { get; set; }
    }
}
