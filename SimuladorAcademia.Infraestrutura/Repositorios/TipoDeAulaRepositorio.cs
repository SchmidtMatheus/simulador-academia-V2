using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Infraestrutura.Dados;

namespace SimuladorAcademia.Infraestrutura.Repositorios
{
    public class TipoAulaRepositorio : ITipoDeAulaRepositorio
    {
        private readonly SimuladorAcademiaDbContext _contexto;

        public TipoAulaRepositorio(SimuladorAcademiaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<TipoDeAula>> ObterTodosAsync(CancellationToken ct)
        {
            return await _contexto.TiposAula
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<TipoDeAula?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _contexto.TiposAula
                .FirstOrDefaultAsync(ta => ta.Id == id, cancellationToken);
        }

        public async Task InserirAsync(TipoDeAula tipoAula, CancellationToken cancellationToken = default)
        {
            await _contexto.TiposAula.AddAsync(tipoAula, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarAsync(TipoDeAula tipoAula, CancellationToken cancellationToken = default)
        {
            _contexto.TiposAula.Update(tipoAula);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tipoAula = await _contexto.TiposAula.FirstOrDefaultAsync(ta => ta.Id == id, cancellationToken);
            if (tipoAula == null) return false;

            _contexto.TiposAula.Remove(tipoAula);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
