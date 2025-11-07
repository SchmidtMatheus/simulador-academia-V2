using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Infraestrutura.Dados;

namespace SimuladorAcademia.Infraestrutura.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly SimuladorAcademiaDbContext _contexto;

        public AlunoRepositorio(SimuladorAcademiaDbContext contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<Aluno> ObterQuery()
        {
            return _contexto.Alunos
                .Include(a => a.TipoDePlano)
                .AsNoTracking();
        }

        public async Task<Aluno?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Alunos
                .Include(a => a.TipoDePlano)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
        }

        public async Task InserirAsync(Aluno aluno, CancellationToken cancellationToken = default)
        {
            await _contexto.Alunos.AddAsync(aluno, cancellationToken);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task AtualizarAsync(Aluno aluno, CancellationToken cancellationToken = default)
        {
            _contexto.Alunos.Update(aluno);
            await _contexto.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var aluno = await _contexto.Alunos.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
            if (aluno == null)
                return false;

            _contexto.Alunos.Remove(aluno);
            await _contexto.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
