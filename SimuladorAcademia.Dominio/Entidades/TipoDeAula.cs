
namespace SimuladorAcademia.Dominio.Entidades
{
    public class TipoDeAula
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public bool IsAtivo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? ApagadoEm { get; set; }

        public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
    }
}
