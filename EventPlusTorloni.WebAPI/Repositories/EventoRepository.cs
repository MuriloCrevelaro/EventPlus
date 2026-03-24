using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EventPlusTorloni.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;
    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, Evento evento)
    {
        var eventoAtualizado = _context.Eventos.Find(id);
        if (eventoAtualizado != null)
        {
            eventoAtualizado!.Nome = evento.Nome;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método que busca eventos no qual um usuario espesifico está presente, ou seja eventos que o usuário confirmou presença.
    /// </summary>
    /// <param name="IdUsuario">Id do usuário a ser buscado</param>
    /// <returns></returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
       .Include(e => e.IdTipoEventoNavigation)
       .Include(e => e.IdInstituiçãoNavigation)
       .Where(e => e.Presencas.Any(propa => propa.IdUsuario ==
        IdUsuario && propa.Situacao == true))
       .ToList();
    }

    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Delete(Guid IdEvento)
    {
        var eventoBuscado = _context.Eventos.Find(IdEvento);
        _context.Eventos.Remove(eventoBuscado!);
        _context.SaveChanges();
    }


    public List<Evento> Listar()
    {
        return _context.Eventos.OrderBy(tipoEvento => tipoEvento.Nome).ToList();
    }

    /// <summary>
    /// Método que retorna uma lista dos proximos eventos
    /// </summary>
    /// <returns>Uma lsita de eventos</returns>
    public List<Evento> ProximosEventos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituiçãoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}
