
namespace SimuladorAcademia.Aplicacao.DTOs
{
    public record AulaDTO
    {
        public Guid Id { get; set; }
        public string TipoDeAulaNome { get; set; } = string.Empty;
        public DateTime DataAgendamento { get; set; }
        public int DuracaoEmMinutos { get; set; }
        public int CapacidadeMaxima { get; set; }
        public int QuantidadeDeParticipantes { get; set; }
        public bool IsAtivo { get; set; }
        public bool IsCancelado { get; set; }
        public DateTime CriadoEm { get; set; }
    }

    public record InserirAulaDTO(Guid TipoDeAulaId, DateTime DataAgendamento, int DuracaoEmMinutos, int CapacidadeMaxima);

    public record AtualizarAulaDTO(Guid TipoDeAulaId, DateTime DataAgendamento, int DuracaoEmMinutos, int CapacidadeMaxima, bool IsAtivo, bool IsCancelado);
}
