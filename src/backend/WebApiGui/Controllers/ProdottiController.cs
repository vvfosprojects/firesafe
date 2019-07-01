using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Commands;
using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.CQRS.Commands;
using DomainModel.CQRS.Queries.GetProdottoPerCodice;
using Microsoft.AspNetCore.Mvc;

namespace RockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdottiController : ControllerBase
    {
        private readonly IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult> handler;

        public ProdottiController (IQueryHandler<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult> handler)
        {
            this.handler = handler;
        }

        //GET: api/Prodotti/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<GetProdottoPerCodiceQueryResult> Get(int id)
        {
            var query = new GetProdottoPerCodiceQuery() { Codice = id.ToString() };
            return Ok(this.handler.Handle(query));
        }
    }
}
