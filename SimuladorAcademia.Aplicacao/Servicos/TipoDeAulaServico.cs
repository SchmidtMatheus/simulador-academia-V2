using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Aplicacao.DTOs;

namespace SimuladorAcademia.Aplicacao.Servicos;

public class TipoDeAulaServico : ITipoDeAulaServico
{
    private readonly ITipoDeAulaRepositorio _repositorio;

    public TipoDeAulaServico(ITipoDeAulaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IEnumerable<TipoDeAula>> ObterTodosAsync(CancellationToken ct)
        => await _repositorio.ObterTodosAsync(ct);

    public async Task<TipoDeAula?> ObterPorIdAsync(Guid id, CancellationToken ct)
        => await _repositorio.ObterPorIdAsync(id, ct);

    public async Task<(bool Sucesso, string Mensagem, TipoDeAula? Tipo)> CriarAsync(InserirTipoDeAulaDTO dto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            return (false, "Nome é obrigatório.", null);

        var tipo = new TipoDeAula
        {
            Id = Guid.NewGuid(),
            Nome = dto.Nome,
            Descricao = dto.Descricao,
            IsAtivo = true,
            CriadoEm = DateTime.Now,
            AtualizadoEm = DateTime.Now
        };

        await _repositorio.InserirAsync(tipo);
        return (true, "Tipo de aula criado com sucesso.", tipo);
    }

    public async Task<(bool Sucesso, string Mensagem, TipoDeAula? Tipo)> AtualizarAsync(Guid id, AtualizarTipoDeAulaDTO dto, CancellationToken ct)
    {
        var existente = await _repositorio.ObterPorIdAsync(id, ct);
        if (existente == null)
            return (false, "Tipo de aula não encontrado.", null);

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
            return (false, "Tipo de aula não encontrado.");

        await _repositorio.RemoverAsync(id, ct);
        return (true, "Excluído com sucesso.");
    }
}
