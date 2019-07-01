using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetIntSum
{
    public class GetIntSumQueryHandler : IQueryHandler<GetIntSumQuery, int>
    {
        public int Handle(GetIntSumQuery query)
        {
            return query.First + query.Second;
        }
    }
}
