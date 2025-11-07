using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;

namespace SimuladorAcademia.Aplicacao.Interfaces
{
    public interface IAlunoServico
    {
        Task<RespostaPaginada<AlunoDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken cancellationToken = default);
        Task<AlunoDTO?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, AlunoDTO? Aluno)> CriarAsync(InserirAlunoDTO dto, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem, AlunoDTO? Aluno)> AtualizarAsync(Guid id, AtualizarAlunoDTO dto, CancellationToken cancellationToken = default);
        Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
