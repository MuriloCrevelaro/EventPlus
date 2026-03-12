using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    List<Usuario> Listar();
    Usuario ListarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
    void Delete(Guid IdUsuario);
    void Atualizar(Guid id, Usuario usuario);
}