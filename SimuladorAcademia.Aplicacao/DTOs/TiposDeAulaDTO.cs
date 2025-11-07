
namespace SimuladorAcademia.Aplicacao.DTOs
{
    public record TiposDeAulaMaisFrequentadasDTO
    {
        public Guid TipoDeAulaId { get; set; }
        public string NomeDoTipoDeAula { get; set; } = string.Empty;
        public int NumeroAgendamentos { get; set; }
        public double Porcentagem { get; set; }
    }

    public record InserirTipoDeAulaDTO(string Nome, string? Descricao);

    public record AtualizarTipoDeAulaDTO(string Nome, string? Descricao, bool IsAtivo);
}
