using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Infraestrutura.Dados;

namespace SimuladorAcademia.Infraestrutura.Repositorios
{
    public class TipoPlanoRepositorio : ITipoDePlanoRepositorio
    {
        private readonly SimuladorAcademiaDbContext _contexto;

        public TipoPlanoRepositorio(SimuladorAcademiaDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<TipoDePlano>> ObterTodosAsync(CancellationToken ct)
        {
            return await _contexto.TiposPlano
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<TipoDePlano?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _contexto.TiposPlano
                .FirstOrDefaultAsync(tp => tp.Id == id, cancellationToken);
        }

        public async Task InserirAsync(TipoDePlano tipoPlano, CancellationToken cancellationToken = default)
        {
            await _contexto.TiposPlano.AddAsync(tipoPlano, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarAsync(TipoDePlano tipoPlano, CancellationToken cancellationToken = default)
        {
            _contexto.TiposPlano.Update(tipoPlano);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var tipoPlano = await _contexto.TiposPlano.FirstOrDefaultAsync(tp => tp.Id == id, cancellationToken);
            if (tipoPlano == null) return false;

            _contexto.TiposPlano.Remove(tipoPlano);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
