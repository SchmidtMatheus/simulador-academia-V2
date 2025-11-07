using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Dominio.Contratos
{
    public interface IAlunoRepositorio
    {
        Task<Aluno?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task InserirAsync(Aluno aluno, CancellationToken cancellationToken = default);
        Task AtualizarAsync(Aluno aluno, CancellationToken cancellationToken = default);
        Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
        IQueryable<Aluno> ObterQuery();
    }
}
