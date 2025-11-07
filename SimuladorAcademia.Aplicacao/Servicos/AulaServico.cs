using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;
using SimuladorAcademia.Aplicacao.Mapeadores;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Servicos
{
    public class AulaServico : IAulaServico
    {
        private readonly IAulaRepositorio _repositorio;

        public AulaServico(IAulaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<RespostaPaginada<AulaDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken ct = default)
        {
            var query = _repositorio.ObterQuery();
            var total = await query.CountAsync(ct);

            var aulas = await query
                .Skip(requisicao.Pular)
                .Take(requisicao.Quantidade)
                .ToListAsync(ct);

            return new RespostaPaginada<AulaDTO>(
                aulas.ParaDTO(),
                requisicao.NumeroPagina,
                requisicao.TamanhoPagina,
                total
            );
        }

        public async Task<AulaDTO?> ObterPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var aula = await _repositorio.ObterPorIdAsync(id, ct);
            return aula?.ParaDTO();
        }

        public async Task<(bool Sucesso, string Mensagem, AulaDTO? Aula)> CriarAsync(InserirAulaDTO dto, CancellationToken ct = default)
        {
            var aula = new Aula()
            {
                Id = new Guid(),
                TipoDeAulaId = dto.TipoDeAulaId,
                DataAgendamento = dto.DataAgendamento,
                DuracaoEmMinutos = dto.DuracaoEmMinutos,
                CapacidadeMaxima = dto.CapacidadeMaxima,
                Participantes = 0
            };
            await _repositorio.InserirAsync(aula, ct);

            var aulaComTipoDePlano = await _repositorio.ObterPorIdAsync(aula.Id, ct);
            return (true, "Aula criada com sucesso.", aulaComTipoDePlano?.ParaDTO());
        }

        public async Task<(bool Sucesso, string Mensagem, AulaDTO? Aula)> AtualizarAsync(Guid id, AtualizarAulaDTO dto, CancellationToken ct = default)
        {
            var existente = await _repositorio.ObterPorIdAsync(id, ct);
            if (existente == null)
                return (false, "Aula não encontrada.", null);

            existente.DataAgendamento = dto.DataAgendamento;
            existente.DuracaoEmMinutos = dto.DuracaoEmMinutos;
            existente.CapacidadeMaxima = dto.CapacidadeMaxima;
            existente.IsAtivo = dto.IsAtivo;
            existente.IsCancelado = dto.IsCancelado;
            existente.AtualizadoEm = DateTime.Now;

            await _repositorio.AtualizarAsync(existente, ct);
            return (true, "Aula atualizada com sucesso.", existente.ParaDTO());
        }

        public async Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken ct = default)
        {
            var existente = await _repositorio.ObterPorIdAsync(id, ct);
            if (existente == null)
                return (false, "Tipo de aula não encontrado.");

            await _repositorio.RemoverAsync(id, ct);
            return (true, "Excluído com sucesso.");
        }
    }
}
