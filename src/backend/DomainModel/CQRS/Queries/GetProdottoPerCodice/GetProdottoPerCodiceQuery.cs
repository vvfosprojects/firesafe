using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQuery : IQuery<GetProdottoPerCodiceQueryResult>
    {
        /// <summary>
        /// Rappresenta il codice (Prog.) di un prodotto
        /// </summary>
        public string Codice { get; set; }
    }
}
