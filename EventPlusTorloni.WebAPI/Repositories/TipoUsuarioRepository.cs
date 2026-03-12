using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlusTorloni.WebAPI.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _context;
    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var tipoUsuariosBuscado = _context.TipoUsuarios.Find(id);
        if (tipoUsuariosBuscado != null)
        {
            tipoUsuariosBuscado.Titulo = tipoUsuario.Titulo;
            //O SaveChange() detecta a mudança na propriedade "Titulo" automaticamente
            _context.SaveChanges();
        }
    }

    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Busca um tipo de usuario por id
    /// </summary>
    /// <param name="id"> id do tipo usuario a ser buscado</param>
    /// <returns>objeto do suario buscado com as informações do tipo de evento buscado</returns>
    public TipoUsuario BuscarPorId(Guid id)
    {
        return _context.TipoUsuarios.Find(id)!;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tipoUsuario"></param>
    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

    public void Cadastrar(TipoEvento tipoEvento)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Deletar(Guid id)
    {
        var tipoUsuariosBuscado = _context.TipoUsuarios.Find(id);
        if (tipoUsuariosBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuariosBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(TipoUsuario => TipoUsuario.Titulo).ToList();
    }

    Usuario ITipoUsuarioRepository.BuscarPorId(Guid id)
    {
        throw new NotImplementedException();
    }
}
