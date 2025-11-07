using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;

namespace SimuladorAcademia.Aplicacao.Interfaces
{
    public interface IAulaServico
    {
        Task<RespostaPaginada<AulaDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken cancellationToken = default);

        Task<AulaDTO?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<(bool Sucesso, string Mensagem, AulaDTO? Aula)> CriarAsync(InserirAulaDTO dto, CancellationToken cancellationToken = default);

        Task<(bool Sucesso, string Mensagem, AulaDTO? Aula)> AtualizarAsync(Guid id, AtualizarAulaDTO dto, CancellationToken cancellationToken = default);

        Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
