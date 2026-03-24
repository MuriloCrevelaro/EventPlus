using Azure;
using Azure.AI.ContentSafety;
using EventPlusTorloni.WebAPI.DTO;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using EventPlusTorloni.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlusTorloni.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private IComentarioEventoRepository _comentarioEventoRepository;
    private readonly ContentSafetyClient _contentSafetyClient;
    public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository, ContentSafetyClient contentSafetyClient)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_comentarioEventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    //[HttpGet]
    //public IActionResult ListarSomenteExibe()
    //{
    //    try
    //    {
    //        return Ok(_comentarioEventoRepository.ListarSomenteExibe(if(Exibe));
    //    }
    //    catch (Exception erro)
    //    {
    //        return BadRequest(erro.Message);
    //    }
    //}

    [HttpGet("Usuario/{IdUsuario}")]
    public IActionResult BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(IdUsuario, IdEvento));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que cadastra e modera um comentário
    /// </summary>
    /// <param name="comentarioEvento">comentário a ser moderado</param>
    /// <returns>Status Code  201 e o comentário criado</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("O texto a ser moderado não pode estar vazio.");
            }

            //Criar objeto de análise
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            //Chamar a api da Azure Content Safety
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            //Verifica se o texto sem alguma severidade maior que 0
            bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(comentario => comentario.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                Descricao = comentarioEvento.Descricao!,
                IdUsuario = comentarioEvento.IdUsuario,
                IdEvento = comentarioEvento.IdEvento,
                DataComentario = DateTime.Now,
                //Define se o comentario vai ser exibido
                Exibe = !temConteudoImproprio
            };
            _comentarioEventoRepository.Cadastrar(novoComentario);
            return StatusCode(201, comentarioEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpDelete]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
