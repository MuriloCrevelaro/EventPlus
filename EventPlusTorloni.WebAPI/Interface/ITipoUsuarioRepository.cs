using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
    List<TipoUsuario> Listar();
    void Atualizar(Guid id, TipoUsuario tipoUsuario);
    void Deletar(Guid id);
}
