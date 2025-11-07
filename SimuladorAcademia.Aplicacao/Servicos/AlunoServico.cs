using Microsoft.EntityFrameworkCore;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;
using SimuladorAcademia.Aplicacao.Mapeadores;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Servicos;

public class AlunoServico : IAlunoServico
{
    private readonly IAlunoRepositorio _repositorio;

    public AlunoServico(IAlunoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<RespostaPaginada<AlunoDTO>> ObterTodosAsync(RequisicaoPaginada requisicao, CancellationToken ct)
    {
        var query = _repositorio.ObterQuery();

        var totalItens = await query.CountAsync(ct);
        var itens = await query
            .Skip(requisicao.Pular)
            .Take(requisicao.Quantidade)
            .ToListAsync(ct);

        return new RespostaPaginada<AlunoDTO>(itens.ParaDTO(), requisicao.NumeroPagina, requisicao.TamanhoPagina, totalItens);
    }

    public async Task<AlunoDTO?> ObterPorIdAsync(Guid id, CancellationToken ct)
    {
        var aluno = await _repositorio.ObterPorIdAsync(id, ct);
        return aluno?.ParaDTO();
    }

    public async Task<(bool Sucesso, string Mensagem, AlunoDTO? Aluno)> CriarAsync(InserirAlunoDTO dto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Email))
            return (false, "Nome e Email são obrigatórios.", null);

        var aluno = new Aluno
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone,
            TipoDePlanoId = dto.TipoDePlanoId,
            IsAtivo = true,
            CriadoEm = DateTime.Now,
            AtualizadoEm = DateTime.Now
        };

        await _repositorio.InserirAsync(aluno, ct);

        var alunoComTipoDePlano = await _repositorio.ObterPorIdAsync(aluno.Id, ct);
        return (true, "Aluno criado com sucesso.", alunoComTipoDePlano?.ParaDTO());
    }

    public async Task<(bool Sucesso, string Mensagem, AlunoDTO? Aluno)> AtualizarAsync(Guid id, AtualizarAlunoDTO dto, CancellationToken ct)
    {
        var existente = await _repositorio.ObterPorIdAsync(id);
        if (existente == null)
            return (false, "Aluno não encontrado.", null);

        existente.Nome = dto.Nome;
        existente.Email = dto.Email;
        existente.Telefone = dto.Telefone;
        existente.TipoDePlanoId = dto.TipoDePlanoId;
        existente.IsAtivo = dto.IsAtivo;
        existente.AtualizadoEm = DateTime.Now;

        await _repositorio.AtualizarAsync(existente, ct);
        return (true, "Atualizado com sucesso.", existente.ParaDTO());
    }

    public async Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken ct)
    {
        var existente = await _repositorio.ObterPorIdAsync(id, ct);
        if (existente == null)
            return (false, "Aluno não encontrado.");

        await _repositorio.RemoverAsync(id, ct);
        return (true, "Aluno removido com sucesso.");
    }
}
