using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _eventContext;
    //Contrutor para usar a injeção de ependencia
    public PresencaRepository(EventContext eventContext)
    {
        _eventContext = eventContext;
    }

    public void Atualizar(Guid IdPresencaBuscada)
    {
        var presecaAtualizada = _eventContext.Presencas.Find(IdPresencaBuscada);
        if(presecaAtualizada != null)
        {
            presecaAtualizada.Situacao = !presecaAtualizada.Situacao;
            _eventContext.SaveChanges();
        }
    }

    /// <summary>
    /// Busca uma presenca  por id
    /// </summary>
    /// <param name="id"> id da preseça a ser buscada</param>
    /// <returns>preseça buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _eventContext.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituiçãoNavigation)
            .FirstOrDefault(e => e!.IdPresenca == id)!;
    }

    /// <summary>
    /// Deleta uma presença
    /// </summary>
    /// <param name="id"></param>
    public void Deletar(Guid id)
    {
        var presecaBuscado = _eventContext.Presencas.Find(id);
        if (presecaBuscado == null)
        {
            _eventContext.Presencas.Remove(presecaBuscado!);
            _eventContext.SaveChanges();
        }
    }

    public void Inscrever(Presenca Inscrisao)
    {
        _eventContext.Presencas.Add(Inscrisao);
        _eventContext.SaveChanges();
    }

    /// <summary>
    /// Busca a lista de preseças cadastradas 
    /// </summary>
    /// <returns></returns>
    public List<Presenca> Listar()
    {
        return _eventContext.Presencas.OrderBy(presenca => presenca.Situacao).ToList();
    }


    /// <summary>
    /// Lista as preseça de um usuário em especifico
    /// </summary>
    /// <param name="IdUsuario">id do usuário para filtrar</param>
    /// <returns>uma Lista de presencas de um usuário específico</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _eventContext.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituiçãoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }
}
