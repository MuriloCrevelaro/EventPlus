using EventPlusTorloni.WebAPI.BdContextEvent;
using EventPlusTorloni.WebAPI.Interface;
using EventPlusTorloni.WebAPI.Models;

namespace EventPlusTorloni.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _context;
        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }

        public void Cadastrar(Instituicao Instituicao)
        {
            _context.Instituicaos.Add(Instituicao);
            _context.SaveChanges();
        }
        public Instituicao BuscarPorId(Guid id)
        {
            return _context.Instituicaos.Find(id)!;
        }

        public void Atualizar(Guid id, Instituicao Instituicao)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);
            if (instituicaoBuscada != null)
            {
                instituicaoBuscada.Cnpj = string.IsNullOrWhiteSpace(Instituicao.Cnpj) ? instituicaoBuscada.Cnpj : Instituicao.Cnpj;
                instituicaoBuscada.NomeFantasia = string.IsNullOrWhiteSpace(Instituicao.NomeFantasia) ? instituicaoBuscada.NomeFantasia : Instituicao.NomeFantasia;
                instituicaoBuscada.Endereço = string.IsNullOrWhiteSpace(Instituicao.Endereço) ? instituicaoBuscada.Endereço : Instituicao.Endereço;
                _context.SaveChanges();
            }
        }

        public void Deletar(Guid id)
        {
            var instituicaoBuscada = _context.Instituicaos.Find(id);
            if (instituicaoBuscada != null)
            {
                _context.Instituicaos.Remove(instituicaoBuscada);
                _context.SaveChanges();
            }
        }

        public List<Instituicao> Listar()
        {
            return _context.Instituicaos.OrderBy(Instituicao => Instituicao.NomeFantasia).ToList();
        }
    }
}
