using CQRS.Queries;
using DomainModel.Services;
using System;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQueryHandler : IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult>
    {
        private readonly IGetProdottoByCodice getProdottoByCodice;

        public GetProdottoPerCodiceQueryHandler(IGetProdottoByCodice getProdottoByCodice)
        {
            this.getProdottoByCodice = getProdottoByCodice ?? throw new ArgumentNullException(nameof(getProdottoByCodice));
        }

        public GetProdottoPerCodiceQueryResult Handle(GetProdottoPerCodiceQuery query)
        {
            return new GetProdottoPerCodiceQueryResult()
            {
                Prodotto = this.getProdottoByCodice.Get(query.Codice)
            };
        }
    }
}
