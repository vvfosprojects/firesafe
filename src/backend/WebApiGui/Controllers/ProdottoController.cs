using CQRS.Queries;
using DomainModel.CQRS.Queries.GetProdottoPerCodice;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottoController : ControllerBase
    {
        private readonly IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult> handler;

        public ProdottoController(IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult> handler)
        {
            this.handler = handler;
        }

        //GET: api/Prodotti/5
        /// <summary>
        ///   Ritorna il singolo prodotto, ricercato per codice, se presente.
        /// </summary>
        /// <param name="id">Rappresenta il codice di un prodotto da ricercare</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<GetProdottoPerCodiceQueryResult> Get(string id)
        {
            var query = new GetProdottoPerCodiceQuery() { Codice = id };

            return Ok(this.handler.Handle(query));
        }
    }
}
