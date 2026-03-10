using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Interface;

public interface IInstituicaoRepository
{
    List<Instituicao> Listar();
    void Cadastrar(Instituicao instituicao);
    void Atualizar(Guid id, Instituicao instituicao);
    void Deletar(Guid id);
    void BuscarPorId(Guid id);
}
