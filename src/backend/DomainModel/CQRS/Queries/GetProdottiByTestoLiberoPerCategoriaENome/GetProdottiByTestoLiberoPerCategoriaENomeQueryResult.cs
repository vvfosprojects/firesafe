using DomainModel.Classes;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome
{
    public class GetProdottiByTestoLiberoPerCategoriaENomeQueryResult
    {
        public CriteriRicerca Criteri { get; set; }

        public RisultatiRicerca Risultati { get; set; }

        public Facet[] FacetCategorie { get; set; }

        public FacetAnnoFirmaConvenzione[] FacetAnnoFirmaConvenzione { get; set; }

        public FacetAnnoScadenzaConvenzione[] FacetAnnoScadenzaConvenzione { get; set; }

        public Prodotto[] Prodotti { get; set; }
    }
}
