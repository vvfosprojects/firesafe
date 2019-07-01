using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Queries;
using DomainModel.Services;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQueryHandler : IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult>
    {
        private readonly IGetProdottoByCodice getProdottoByCodice;

        public GetProdottoPerCodiceQueryHandler(IGetProdottoByCodice getProdottoByCodice)
        {
            this.getProdottoByCodice = getProdottoByCodice ?? throw new ArgumentNullException(nameof(getProdottoByCodice));
        }

        public GetProdottoPerCodiceQueryResult Handle (GetProdottoPerCodiceQuery query)
        {
            return new GetProdottoPerCodiceQueryResult()
            {
                Prodotto = this.getProdottoByCodice.Get(query.Codice)
            };
        }
    }
}
