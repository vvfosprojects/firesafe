using CQRS.Queries;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using Microsoft.AspNetCore.Mvc;

namespace Firesafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private readonly IQueryHandler<GetProdottiByTestoLiberoQuery, GetProdottiByTestoLiberoQueryResult> handler;

        public ProdottiController(IQueryHandler<GetProdottiByTestoLiberoQuery, GetProdottiByTestoLiberoQueryResult> handler)
        {
            this.handler = handler;
        }

        [HttpGet("{key}&{page}&{pageSize}&{categorie}")]
        public ActionResult<GetProdottiByTestoLiberoQueryResult> Get(string key, int page, int pageSize, string[] categorie)
        {
            var query = new GetProdottiByTestoLiberoQuery()
            {
                Categorie = categorie,
                Page = page,
                PageSize = pageSize,
                Key = key
            };

            return Ok(this.handler.Handle(query));
        }
    }
}
