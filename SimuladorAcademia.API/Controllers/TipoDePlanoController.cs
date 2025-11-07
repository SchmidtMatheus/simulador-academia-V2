using Microsoft.AspNetCore.Mvc;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.Interfaces;

namespace SimuladorAcademia.API.Controllers
{
    [ApiController]
    [Route("api/tipo-de-plano")]
    public class TipoDePlanoController : ControllerBase
    {
        private readonly ITipoDePlanoServico _service;

        public TipoDePlanoController(ITipoDePlanoServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos(CancellationToken ct)
        {
            var tipos = await _service.ObterTodosAsync(ct);
            return Ok(tipos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken ct)
        {
            var tipo = await _service.ObterPorIdAsync(id, ct);
            if (tipo == null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InserirTipoDePlanoDTO dto, CancellationToken ct)
        {
            var resultado = await _service.CriarAsync(dto, ct);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Tipo!.Id }, resultado.Tipo);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarTipoDePlanoDTO dto, CancellationToken ct)
        {
            var resultado = await _service.AtualizarAsync(id, dto, ct);
            if (!resultado.Sucesso)
                return NotFound(resultado.Mensagem);

            return Ok(resultado.Tipo);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken ct)
        {
            var resultado = await _service.RemoverAsync(id, ct);
            if (!resultado.Sucesso)
                return NotFound(resultado.Mensagem);

            return NoContent();
        }
    }
}
