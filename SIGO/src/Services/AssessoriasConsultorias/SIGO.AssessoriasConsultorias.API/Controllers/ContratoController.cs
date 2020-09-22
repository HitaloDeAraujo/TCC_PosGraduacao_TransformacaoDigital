﻿using Microsoft.AspNetCore.Mvc;
using SIGO.AssessoriasConsultorias.Domain.Entidades;
using System.Threading.Tasks;

namespace SIGO.AssessoriasConsultorias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            Contrato contrato = new Contrato()
            {
                Nome = "Cont"
            };

            return Ok(contrato);
        }
    }
}