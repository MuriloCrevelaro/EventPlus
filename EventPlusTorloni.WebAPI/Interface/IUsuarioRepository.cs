using EventPlusTorloni.WebAPI.DTO;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    List<Usuario> Listar();
    Usuario BuscarPorId(Guid id);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
    void Delete(Guid IdUsuario);
    void Atualizar(Guid id, Usuario usuario);
}