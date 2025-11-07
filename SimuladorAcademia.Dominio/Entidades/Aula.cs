
namespace SimuladorAcademia.Dominio.Entidades
{
    public class Aula
    {
        public Guid Id { get; set; }
        public Guid TipoDeAulaId { get; set; }
        public TipoDeAula TipoDeAula { get; set; } = null!;
        public DateTime DataAgendamento { get; set; }
        public int DuracaoEmMinutos { get; set; } = 60;
        public int CapacidadeMaxima { get; set; }
        public int Participantes { get; set; } = 0;
        public bool IsAtivo { get; set; } = true;
        public bool IsCancelado { get; set; } = false;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? ApagadoEm { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
