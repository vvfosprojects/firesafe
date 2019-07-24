using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Firesafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        // GET: api/Healthcheck
        [HttpGet]
        public object Get()
        {
            return new
            {
                State = "SUCCESS",
                Description = string.Empty
            };
        }
    }
}
