using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.Interfaces;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;

namespace SimuladorAcademia.Aplicacao.Servicos;

public class TipoDePlanoServico : ITipoDePlanoServico
{
    private readonly ITipoDePlanoRepositorio _repositorio;

    public TipoDePlanoServico(ITipoDePlanoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<TipoDePlano>> ObterTodosAsync(CancellationToken ct)
        => await _repositorio.ObterTodosAsync(ct);

    public async Task<TipoDePlano?> ObterPorIdAsync(Guid id, CancellationToken ct)
        => await _repositorio.ObterPorIdAsync(id, ct);

    public async Task<(bool Sucesso, string Mensagem, TipoDePlano? Tipo)> CriarAsync(InserirTipoDePlanoDTO dto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            return (false, "Nome é obrigatório.", null);

        var tipo = new TipoDePlano
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            IsAtivo = true,
            CriadoEm = DateTime.Now,
            AtualizadoEm = DateTime.Now
        };

        await _repositorio.InserirAsync(tipo, ct);
        return (true, "Tipo de plano criado com sucesso.", tipo);
    }

    public async Task<(bool Sucesso, string Mensagem, TipoDePlano? Tipo)> AtualizarAsync(Guid id, AtualizarTipoDePlanoDTO dto, CancellationToken ct)
    {
        var existente = await _repositorio.ObterPorIdAsync(id, ct);
        if (existente == null)
            return (false, "Tipo de plano não encontrado.", null);

        existente.Nome = dto.Nome;
        existente.Descricao = dto.Descricao;
        existente.IsAtivo = dto.IsAtivo;
        existente.AtualizadoEm = DateTime.Now;

        await _repositorio.AtualizarAsync(existente, ct);
        return (true, "Atualizado com sucesso.", existente);
    }

    public async Task<(bool Sucesso, string Mensagem)> RemoverAsync(Guid id, CancellationToken ct)
    {
        var existente = await _repositorio.ObterPorIdAsync(id, ct);
        if (existente == null)
            return (false, "Tipo de plano não encontrado.");

        await _repositorio.RemoverAsync(id, ct);
        return (true, "Excluído com sucesso.");
    }
}
