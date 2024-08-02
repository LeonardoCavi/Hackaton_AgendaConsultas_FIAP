using HealthMed.AgendaConsulta.Domain.Entities;

namespace HealthMed.AgendaConsulta.Domain.Interfaces.Repositories
{
    public interface IEntidadeBaseRepository<TEntidade> where TEntidade : EntidadeBase
    {
        Task Inserir(TEntidade entidade);
        Task<TEntidade> Obter(int id);
        Task<ICollection<TEntidade>> ObterTodos();
        Task Atualizar(TEntidade entidade);
        Task Excluir(TEntidade entidade);
    }
}
