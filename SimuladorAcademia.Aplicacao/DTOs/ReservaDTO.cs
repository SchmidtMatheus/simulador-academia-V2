
using SimuladorAcademia.Dominio.Enums;

namespace SimuladorAcademia.Aplicacao.DTOs
{
    public record ReservaDTO
    {
        public Guid Id { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string NomeAula { get; set; } = string.Empty;
        public DateTime DataAgendamento { get; set; }
        public StatusReserva Status { get; set; }

    }

    public record InserirReservaDTO(Guid AlunoId, Guid AulaId);
}
