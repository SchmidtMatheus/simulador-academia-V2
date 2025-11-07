
namespace SimuladorAcademia.Dominio.Entidades
{
    public class TipoDePlano
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public int LimiteAula { get; set; }
        public bool IsAtivo { get; set; } = true;
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; set; } = DateTime.UtcNow;
        public DateTime? ApagadoEm { get; set; }

        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
