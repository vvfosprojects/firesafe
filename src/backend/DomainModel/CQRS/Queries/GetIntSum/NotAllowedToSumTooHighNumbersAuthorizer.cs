using CQRS.Authorization;
using CQRS.Queries.Authorizers;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetIntSum
{
    public class NotAllowedToSumTooHighNumbersAuthorizer : IQueryAuthorizer<GetIntSumQuery, int>
    {
        public IEnumerable<AuthorizationResult> Authorize(GetIntSumQuery query)
        {
            const int maxAllowed = 100;
            if (query.First > maxAllowed || query.Second > maxAllowed)
                yield return new AuthorizationResult($"Cannot sum numbers greater than {maxAllowed}");
        }
    }
}
