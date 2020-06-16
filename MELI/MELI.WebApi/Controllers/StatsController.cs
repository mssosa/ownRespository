using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MELI.Aplication.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MELI.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        public IStat Stat { get; }

        public StatsController(IStat stat)
        {
            Stat = stat;
        }
        [HttpGet]
        public async Task<ActionResult> GetStats()
        {
            try
            {
                var newStats=await Stat.CalculateStats();
                return Ok(newStats);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrio un error inesperado {ex.Message}");
            }
        }
    }
}
