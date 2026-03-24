using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IPresencaRepository
{
    //É o cadastrar só que 2
    void Inscrever(Presenca Inscrisao);
    void Deletar(Guid id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid id);
    void Atualizar(Guid IdPresencaBuscada);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}
