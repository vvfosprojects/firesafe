using DomainModel.Classes;
using System;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class GetProdottiByTestoLiberoQueryResult
    {
        public CriteriRicerca Criteri { get; set; }

        public RisultatiRicerca Risultati { get; set; }

        public Facet[] FacetCategorie { get; set; }

        public FacetAnnoFirmaConvenzione[] FacetAnnoFirmaConvenzione { get; set; }

        public Prodotto[] Prodotti { get; set; }
    }
}
