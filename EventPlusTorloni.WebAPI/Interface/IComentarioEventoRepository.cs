using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IComentarioEventoRepository
{
    void Cadastrar (ComentarioEvento comentarioEvento);
    void Deletar (Guid id);
    //Isso vem das models, que são do banco de dados
    List<ComentarioEvento> Listar(Guid IdEvento);
    ComentarioEvento BuscarPorIdUsuario (Guid IdUsuario, Guid IdEvento);
    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
