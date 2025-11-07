using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Infraestrutura.Dados
{
    public class SimuladorAcademiaDbContext : DbContext
    {
        public SimuladorAcademiaDbContext(DbContextOptions<SimuladorAcademiaDbContext> options)
            : base(options) { }

        public DbSet<Aluno> Alunos { get; set; } = null!;

        public DbSet<TipoDePlano> TiposPlano => Set<TipoDePlano>();
        public DbSet<TipoDeAula> TiposAula => Set<TipoDeAula>();
        public DbSet<Aula> Aulas => Set<Aula>();
        public DbSet<Reserva> Reservas => Set<Reserva>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reserva>()
                .HasIndex(r => new { r.AlunoId, r.AulaId })
                .IsUnique();

            modelBuilder.Entity<TipoDePlano>()
                .HasIndex(p => p.Nome)
                .IsUnique();

            modelBuilder.Entity<TipoDeAula>()
                .HasIndex(t => t.Nome)
                .IsUnique();

            modelBuilder.Entity<Aluno>()
                .HasIndex(a => new { a.Email, a.Nome })
                .IsUnique();

        }
    }
}
