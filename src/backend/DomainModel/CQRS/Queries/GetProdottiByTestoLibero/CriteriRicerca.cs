namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class CriteriRicerca
    {
        public string Key { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] Categorie { get; set; }
    }
}
