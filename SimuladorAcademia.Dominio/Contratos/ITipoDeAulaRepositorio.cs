using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Dominio.Contratos
{
    public interface ITipoDeAulaRepositorio
    {
        Task<List<TipoDeAula>> ObterTodosAsync(CancellationToken ct);
        Task<TipoDeAula?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task InserirAsync(TipoDeAula tipoAula, CancellationToken cancellationToken = default);
        Task AtualizarAsync(TipoDeAula tipoAula, CancellationToken cancellationToken = default);
        Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
