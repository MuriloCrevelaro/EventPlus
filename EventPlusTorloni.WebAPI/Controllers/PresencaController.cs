using EventPlusTorloni.WebAPI.DTO;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using EventPlusTorloni.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlusTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;
    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }


    /// <summary>
    /// Endpoint da API que retorna uma preseça a ser buscada
    /// </summary>
    /// <param name="id">id da presença a ser biscada</param>
    /// <returns> Status code 200 e presença buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que retorna uma lista de preseças filtrada do usuário
    /// </summary>
    /// <param name="idUsurio">id do usuário para filtragem</param>
    /// <returns>uma lista de presenças filtradas pelo usuário</returns>
    [HttpGet("ListarLinha/{IdUsuario}")]
    public IActionResult BuscarPorUsuario(Guid idUsurio)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsurio));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(PresencaDTO preseca)
    {
        try
        {
            var presecaNova = new Presenca
            {
                Situacao = preseca.Situacao
            };
            _presencaRepository.Inscrever(presecaNova);
            return StatusCode(201, presecaNova);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, PresencaDTO preseca)
    {
        try
        {
            var presecaAtualizada = new Presenca
            {
                Situacao = preseca.Situacao
            };
            _presencaRepository.Atualizar(id);
            return StatusCode(204, presecaAtualizada);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
