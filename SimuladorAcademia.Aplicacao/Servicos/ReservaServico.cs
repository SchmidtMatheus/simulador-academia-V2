using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;
using SimuladorAcademia.Aplicacao.Mapeadores;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Servicos
{
    public class ReservaServico : IReservaServico
    {
        private readonly IReservaRepositorio _repositorio;

        public ReservaServico(IReservaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RespostaPaginada<ReservaDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken ct = default)
        {
            var query = _repositorio.ObterQuery();
            var total = await query.CountAsync(ct);

            var reservas = await query
                .Skip(requisicao.Pular)
                .Take(requisicao.Quantidade)
                .ToListAsync(ct);

            return new RespostaPaginada<ReservaDTO>(
                reservas.ParaDTO(),
                requisicao.NumeroPagina,
                requisicao.TamanhoPagina,
                total
            );
        }

        public async Task<ReservaDTO?> ObterPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var reserva = await _repositorio.ObterPorIdAsync(id, ct);
            return reserva?.ParaDTO();
        }

        public async Task<(bool Sucesso, string Mensagem, ReservaDTO? Reserva)> CriarAsync(InserirReservaDTO dto, CancellationToken ct = default)
        {
            var existeReserva = await _repositorio.ExisteReservaAsync(dto.AlunoId, dto.AulaId, ct);


            if (existeReserva)
                return (false, "O aluno já possui uma reserva para esta aula.", null);

            var reserva = new Reserva()
            {
                Id = new Guid(),
                AlunoId = dto.AlunoId,
                AulaId = dto.AulaId
            };
            await _repositorio.InserirAsync(reserva, ct);

            var reservaComNomes = await _repositorio.ObterPorIdAsync(reserva.Id, ct);
            return (true, "Reserva criada com sucesso.", reservaComNomes?.ParaDTO());
        }

        public async Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken ct)
        {
            var existente = await _repositorio.ObterPorIdAsync(id, ct);
            if (existente == null)
                return (false, "Reserva não encontrada.");

            await _repositorio.RemoverAsync(id, ct);
            return (true, "Excluído com sucesso.");
        }
    }
}
