using DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome;

namespace DomainModel.Services
{
    public interface IGetProdottiByTestoLiberoPerCategoriaENome
    {
        GetProdottiByTestoLiberoPerCategoriaENomeQueryResult Get(GetProdottiByTestoLiberoPerCategoriaENomeQuery query);
    }
}
