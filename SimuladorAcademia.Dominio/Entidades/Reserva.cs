
using SimuladorAcademia.Dominio.Enums;

namespace SimuladorAcademia.Dominio.Entidades
{
    public class Reserva
    {
        public Guid Id { get; set; }

        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; } = null!;

        public Guid AulaId { get; set; }
        public Aula Aula { get; set; } = null!;

        public StatusReserva StatusReserva { get; set; } = StatusReserva.Agendado;

        public DateTime DataAgendamento { get; set; } = DateTime.UtcNow;
        public DateTime? CanceladoEm { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? ApagadoEm { get; set; }
    }
}
