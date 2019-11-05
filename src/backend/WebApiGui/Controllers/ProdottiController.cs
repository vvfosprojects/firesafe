using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLibero;
using DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome;
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

        /// <summary>
        ///   Effettua la ricerca full-text di prodotti. Consente anche filtraggio per categorie e
        ///   restituisce, oltre ai risultati di ricerca, anche statistiche (per es. faceting).
        /// </summary>
        /// <param name="criteri">I criteri di ricerca</param>
        /// <returns></returns>
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
