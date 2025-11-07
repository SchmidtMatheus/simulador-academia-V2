using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;

namespace SimuladorAcademia.Aplicacao.Interfaces
{
    public interface IReservaServico
    {
        Task<RespostaPaginada<ReservaDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken ct = default);
        Task<ReservaDTO?> ObterPorIdAsync(Guid id, CancellationToken ct = default);
        Task<(bool Sucesso, string Mensagem, ReservaDTO? Reserva)> CriarAsync(InserirReservaDTO reserva, CancellationToken ct = default);
        Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken ct = default);
    }
}
