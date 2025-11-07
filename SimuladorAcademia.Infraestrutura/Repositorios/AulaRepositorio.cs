using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Infraestrutura.Dados;

namespace SimuladorAcademia.Infraestrutura.Repositorios
{
    public class AulaRepositorio : IAulaRepositorio
    {
        private readonly SimuladorAcademiaDbContext _contexto;

        public AulaRepositorio(SimuladorAcademiaDbContext contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Aula> ObterQuery()
        {
            return _contexto.Aulas
                .Include(a => a.TipoDeAula)
                .AsNoTracking();
        }

        public async Task<Aula?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Aulas
                .Include(a => a.TipoDeAula)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task InserirAsync(Aula aula, CancellationToken cancellationToken = default)
        {
            await _contexto.Aulas.AddAsync(aula, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarAsync(Aula aula, CancellationToken cancellationToken = default)
        {
            _contexto.Aulas.Update(aula);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var aula = await _contexto.Aulas.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            if (aula == null) return false;

            _contexto.Aulas.Remove(aula);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
