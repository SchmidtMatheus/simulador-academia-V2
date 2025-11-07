using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Dominio.Contratos
{
    public interface IReservaRepositorio
    {
        IQueryable<Reserva> ObterQuery();
        Task<Reserva?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task InserirAsync(Reserva reserva, CancellationToken cancellationToken = default);
        Task AtualizarAsync(Reserva reserva, CancellationToken cancellationToken = default);
        Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExisteReservaAsync(Guid alunoId, Guid aulaId, CancellationToken ct);
    }
}
