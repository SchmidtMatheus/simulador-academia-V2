using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Dominio.Contratos
{
    public interface ITipoDePlanoRepositorio
    {
        Task<List<TipoDePlano>> ObterTodosAsync(CancellationToken ct);
        Task<TipoDePlano?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task InserirAsync(TipoDePlano tipoPlano, CancellationToken cancellationToken = default);
        Task AtualizarAsync(TipoDePlano tipoPlano, CancellationToken cancellationToken = default);
        Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
