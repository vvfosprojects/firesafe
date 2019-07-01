using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQuery : IQuery<GetProdottoPerCodiceQueryResult>
    {
        public string Codice { get; set; }
    }
}
