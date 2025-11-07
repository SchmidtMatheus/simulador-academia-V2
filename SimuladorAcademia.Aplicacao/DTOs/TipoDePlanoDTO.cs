
namespace SimuladorAcademia.Aplicacao.DTOs
{
    public record InserirTipoDePlanoDTO(string Nome, string? Descricao, int CapacidadeAlunos);

    public record AtualizarTipoDePlanoDTO(string Nome, string? Descricao, int CapacidadeAlunos, bool IsAtivo);
}
