
namespace SimuladorAcademia.Aplicacao.DTOs
{
    public record AlunoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool IsAtivo { get; set; }
        public string NomeDoTipoDePlano { get; set; } = string.Empty;

    }

    public record RelatorioAlunoDTO
    {
        public Guid AlunoId { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public int TotalAulasEsteMes { get; set; }
        public List<TiposDeAulaMaisFrequentadasDTO> TiposDeAulaMaisFrequentadasDTO { get; set; } = new();
        public DateTime DataRelatorio { get; set; } = DateTime.UtcNow;
    }

    public record InserirAlunoDTO(string Nome, string? Email, string? Telefone, Guid TipoDePlanoId);

    public record AtualizarAlunoDTO(string Nome, string? Email, string? Telefone, Guid TipoDePlanoId, bool IsAtivo);
}
