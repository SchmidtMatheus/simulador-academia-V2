using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Interfaces
{
    public interface ITipoDePlanoServico
    {
        Task<IEnumerable<TipoDePlano>> ObterTodosAsync(CancellationToken cancellationToken = default);
        Task<TipoDePlano?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, TipoDePlano? Tipo)> CriarAsync(InserirTipoDePlanoDTO dto, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, TipoDePlano? Tipo)> AtualizarAsync(Guid id, AtualizarTipoDePlanoDTO dto, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
