using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Dominio.Contratos
{
    public interface ITipoDeAulaServico
    {
        Task<IEnumerable<TipoDeAula>> ObterTodosAsync(CancellationToken cancellationToken = default);
        Task<TipoDeAula?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, TipoDeAula? Tipo)> CriarAsync(InserirTipoDeAulaDTO dto, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, TipoDeAula? Tipo)> AtualizarAsync(Guid id, AtualizarTipoDeAulaDTO tipo, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
