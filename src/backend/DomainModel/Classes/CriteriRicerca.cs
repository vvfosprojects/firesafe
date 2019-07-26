namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class CriteriRicerca
    {
        /// <summary>
        ///   La chiave full-text di ricerca
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///   La pagina dei risultati desiderata
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        ///   La lunghezza della pagina
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///   L'elenco delle categorie nelle quali si intende ricercare. In caso di elenco vuoto,
        ///   questo filtro non ha alcun effetto.
        /// </summary>
        public string[] Categorie { get; set; }
    }
}
