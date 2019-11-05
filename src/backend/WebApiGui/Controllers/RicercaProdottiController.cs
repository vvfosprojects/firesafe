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
    }
}