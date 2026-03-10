using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface ITipoUsuarioRepository
{
    List<TipoEventos> Listar();
    void Cadastrar (TipoEventos tipoUsuario);
    void Atualizar(Guid id, TipoEventos tipoUsuario);
    void Deletar(Guid id);
    TipoEventos BuscarPorId(Guid id);
}
