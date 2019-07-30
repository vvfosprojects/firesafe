using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class GetProdottiByTestoLiberoQuery : IQuery<GetProdottiByTestoLiberoQueryResult>
    {
        /// <summary>
        /// Rappresenta la/e chiave/i immesse utilizate per la ricerca
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Rappresenta la pagina dei prodotti richiesta
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Rappresenta il numero di prodotti visualizzabili in ogni pagina (max valore = 20) 
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Rappresenta l'array contenente le categorie utilizzate per la ricerca
        /// </summary>
        public string[] Categorie { get; set; }
    }
}
