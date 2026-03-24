using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;
    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        return _context.ComentarioEventos.Find(IdUsuario, IdEvento)!;
    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
        var comentarioBuscada = _context.ComentarioEventos.Find(id);
        if (comentarioBuscada != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscada);
            _context.SaveChanges();
        }
    }

    public List<ComentarioEvento> Listar()
    {
        return _context.ComentarioEventos.OrderBy(ComentarioEventos => ComentarioEventos.Descricao).ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        throw new NotImplementedException();
    }
}
