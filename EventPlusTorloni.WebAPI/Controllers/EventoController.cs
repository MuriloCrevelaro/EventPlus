using EventPlusTorloni.WebAPI.DTO;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlusTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;
    public EventoController(IEventoRepository eventoRepository)
    {
           _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// Endpoint daq API que faz a chamada para o método do Id do Usuario
    /// </summary>
    /// <param name="Id">Id fo usuário para filtragem</param>
    /// <returns>Status code 200 e uma lista de eventos</returns>
    [HttpGet("Usuario/{IdUsuario}")]
    public IActionResult ListarPorId(Guid IdUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(IdUsuario));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de Listar os próximos eventos 
    /// </summary>
    /// <returns>Status 200 e a Lista dos próximos eventos</returns>
    [HttpGet("ListarProximos")]
    public IActionResult ProximosEventos()
    {
        try
        {
            return Ok(_eventoRepository.ProximosEventos());
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamada para o método de cadastrar um novo evento
    /// </summary>
    /// <param name="tipoEvento">Evento a ser cadastrado</param>
    /// <returns>Status code 201 e o evento cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                IdTipoEvento = evento.IdTipoEvento!,
                DataEvento = evento.DataEvento,
                Descricao = evento.Descricao!,
                IdInstituição = evento.IdInstituição!
            };
            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, evento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var eventoAtualizado = new Evento
            {
                Nome = evento.Nome!,
                IdTipoEvento = evento.IdTipoEvento!,
                DataEvento = evento.DataEvento,
                Descricao = evento.Descricao!,
                IdInstituição = evento.IdInstituição!
            };
            _eventoRepository.Atualizar(id, eventoAtualizado);
            return StatusCode(204, eventoAtualizado);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _eventoRepository.Delete(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
