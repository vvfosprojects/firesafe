using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using System.Collections.Generic;

namespace DomainModel.Services
{
    public interface IGetProdottiByTestoLibero
    {
        GetProdottiByTestoLiberoQueryResult Get(GetProdottiByTestoLiberoQuery query);
    }
}
