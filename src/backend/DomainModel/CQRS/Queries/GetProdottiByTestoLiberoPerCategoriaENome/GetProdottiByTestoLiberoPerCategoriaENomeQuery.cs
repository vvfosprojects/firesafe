using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome
{
    public class GetProdottiByTestoLiberoPerCategoriaENomeQuery : IQuery<GetProdottiByTestoLiberoPerCategoriaENomeQueryResult>
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

        /// <summary>
        /// Rappreseta l'anno in cui il prodotto ha ricevuto l'omologazione 
        /// </summary>
        public int?[] AnnoFirmaConvenzione { get; set; }

        /// <summary>
        /// Rappresenta l'anno in cui scade l'omologazione per il prodotto
        /// </summary>
        public int?[] AnnoScadenzaConvenzione { get; set; }
    }
}
