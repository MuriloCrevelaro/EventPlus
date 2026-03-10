using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IPresencaRepository
{
    //É o cadastrar só que 2
    void Inscrever(Presenca Inscrisao);
    void Dletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid id, Presenca presenca);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}
