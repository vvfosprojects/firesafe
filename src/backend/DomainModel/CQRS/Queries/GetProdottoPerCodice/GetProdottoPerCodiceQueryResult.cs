using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Classes;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQueryResult
    {
        public Prodotto Prodotto { get; set; }
    }
}
