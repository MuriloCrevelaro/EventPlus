using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);
    List<Evento> Listar();
    List<Evento> ListarPorId(Guid id);
    List<Evento> ProximosEventos();
    void Delete(Guid IdEvento);
    void Atualizar(Guid id, Evento evento);

}
