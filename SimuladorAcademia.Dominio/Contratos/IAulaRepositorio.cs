using global::SimuladorAcademia.Dominio.Entidades;

    namespace SimuladorAcademia.Dominio.Contratos
    {
        public interface IAulaRepositorio
        {
            IQueryable<Aula> ObterQuery();
            Task<Aula?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
            Task InserirAsync(Aula aula, CancellationToken cancellationToken = default);
            Task AtualizarAsync(Aula aula, CancellationToken cancellationToken = default);
            Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
        }
    }
