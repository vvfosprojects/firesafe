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

        [HttpGet]
        public ActionResult<GetProdottiByTestoLiberoQueryResult> Get([FromQuery] CriteriRicerca criteri)
        {
            var query = new GetProdottiByTestoLiberoQuery()
            {
                Categorie = criteri.Categorie ?? new string[0],
                Page = criteri.Page,
                PageSize = criteri.PageSize,
                Key = criteri.Key
            };

            return Ok(this.handler.Handle(query));
        }
    }
}
