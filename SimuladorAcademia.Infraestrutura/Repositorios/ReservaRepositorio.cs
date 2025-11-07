using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Infraestrutura.Dados;

namespace SimuladorAcademia.Infraestrutura.Repositorios
{
    public class ReservaRepositorio : IReservaRepositorio
    {
        private readonly SimuladorAcademiaDbContext _contexto;

        public ReservaRepositorio(SimuladorAcademiaDbContext contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Reserva> ObterQuery()
        {
            return _contexto.Reservas
                .Include(r => r.Aula)
                    .ThenInclude(a => a.TipoDeAula)
                .Include(r => r.Aluno)
                    .ThenInclude(a => a.TipoDePlano)
                .AsNoTracking();
        }

        public async Task<Reserva?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Reservas
                .Include(r => r.Aula)
                    .ThenInclude(a => a.TipoDeAula)
                .Include(r => r.Aluno)
                    .ThenInclude(a => a.TipoDePlano)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public Task<bool> ExisteReservaAsync(Guid alunoId, Guid aulaId, CancellationToken ct = default)
        {
            return ObterQuery().AnyAsync(r => r.AlunoId == alunoId && r.AulaId == aulaId, ct);
        }

        public async Task<int> ContarReservasAtivasDoAlunoAsync(Guid alunoId, CancellationToken ct = default)
        {
            return await _contexto.Reservas
                .CountAsync(r => r.AlunoId == alunoId, ct);
        }

        public async Task InserirAsync(Reserva reserva, CancellationToken cancellationToken = default)
        {
            await _contexto.Reservas.AddAsync(reserva, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarAsync(Reserva reserva, CancellationToken cancellationToken = default)
        {
            _contexto.Reservas.Update(reserva);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var reserva = await _contexto.Reservas.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
            if (reserva == null) return false;

            _contexto.Reservas.Remove(reserva);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
