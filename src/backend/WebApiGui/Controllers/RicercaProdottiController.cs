using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome;
using Microsoft.AspNetCore.Mvc;

namespace Firesafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RicercaProdottiController : ControllerBase
    {
        private readonly IQueryHandler<GetProdottiByTestoLiberoPerCategoriaENomeQuery, GetProdottiByTestoLiberoPerCategoriaENomeQueryResult> handler;

        public RicercaProdottiController(IQueryHandler<GetProdottiByTestoLiberoPerCategoriaENomeQuery, GetProdottiByTestoLiberoPerCategoriaENomeQueryResult> handler)
        {
            this.handler = handler;
        }


        [HttpGet]
        public ActionResult<GetProdottiByTestoLiberoPerCategoriaENomeQueryResult> Get([FromQuery] CriteriRicerca criteri)
        {
            var query = new GetProdottiByTestoLiberoPerCategoriaENomeQuery()
            {
                Categorie = criteri.Categorie,
                Page = criteri.Page,
                PageSize = criteri.PageSize,
                Key = criteri.Key,
                AnnoFirmaConvenzione = criteri.AnnoFirmaConvenzione,
                AnnoScadenzaConvenzione = criteri.AnnoScadenzaConvenzione
            };

            return Ok(this.handler.Handle(query));
        }
    }
}