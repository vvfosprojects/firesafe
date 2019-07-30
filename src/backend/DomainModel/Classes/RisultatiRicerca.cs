namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class RisultatiRicerca
    {
        /// <summary>
        /// Indica il numero totale di prodotti nel db
        /// </summary>
        public int Totale { get; set; }
        /// <summary>
        /// Indica il numero di oggetti filtrati tramite la ricerca
        /// </summary>
        public int Filtrati { get; set; }
        /// <summary>
        /// Primo indice della paginazione
        /// </summary>
        public int FirstIndex { get; set; }
        /// <summary>
        /// Indice finale della paginazione
        /// </summary>
        public int LastIndex { get; set; }
    }
}
