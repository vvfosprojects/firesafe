using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQuery : IQuery<GetProdottoPerCodiceQueryResult>
    {
        public string Codice { get; set; }
    }
}
