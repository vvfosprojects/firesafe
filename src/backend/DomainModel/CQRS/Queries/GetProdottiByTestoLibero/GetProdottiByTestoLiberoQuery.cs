using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class GetProdottiByTestoLiberoQuery : IQuery<GetProdottiByTestoLiberoQueryResult>
    {
        public string Key { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string[] Categorie { get; set; }
    }
}
