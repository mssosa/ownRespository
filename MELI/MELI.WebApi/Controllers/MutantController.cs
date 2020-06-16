using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MELI.Aplication.UseCases;
using MELI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MELI.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MutantController : ControllerBase
    {
        public IIsMutant Mutant { get; }
        /// <summary>
        /// Constructor with DI of IISMutant
        /// </summary>
        /// <param name="mutant"></param>
        public MutantController(IIsMutant mutant)
        {
            Mutant = mutant;
        }
        /// <summary>
        /// Api spoced to web that receipt an object in JSON
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post(ReceiptDNA receipt)
        {
            try
            {
                var isMutant = await Mutant.isMutant(receipt.dna);
                if (isMutant)
                    return Ok();
                else
                    return StatusCode(403);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrio un error inesperado {ex.Message}");
            }
        }
    }
}
