using EventPlusTorloni.WebAPI.Interface;
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

    //[HttpPost]
    //public IActionResult Cadas
}
