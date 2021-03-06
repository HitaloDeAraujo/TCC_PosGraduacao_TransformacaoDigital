﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIGO.Domain;
using SIGO.GestaoNormas.Domain.DTOs;
using SIGO.GestaoNormas.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace SIGO.GestaoNormas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = Autorizacao.Grupo.ADMINISTRADOR)]
    public class RepositorioController : ControllerBase
    {
        private readonly IRepositorioService _repositorioService;

        public RepositorioController(IRepositorioService repositorioService)
        {
            _repositorioService = repositorioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var repositorios = await _repositorioService.ObterRepositorios();

            return Ok(repositorios);
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> Get(string guid)
        {
            var repositorio = await _repositorioService.ObterRepositorio(guid);

            return Ok(repositorio);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RepositorioDTO repositorioDTO)
        {
            var repositorio = await _repositorioService.Salvar(repositorioDTO.ToRepositorio());

            if (repositorio.ID != 0)
                return Ok(repositorio);
            else
                return BadRequest();
        }
    }
}