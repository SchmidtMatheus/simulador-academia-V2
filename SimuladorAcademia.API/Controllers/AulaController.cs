using Microsoft.AspNetCore.Mvc;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;

namespace SimuladorAcademia.API.Controllers
{
    [ApiController]
    [Route("api/aula")]
    public class AulaController : ControllerBase
    {
        private readonly IAulaServico _service;

        public AulaController(IAulaServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] RequisicaoPaginada requisicao, CancellationToken ct)
        {
            var resultado = await _service.ObterTodosAsync(requisicao, ct);
            return Ok(resultado);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken ct)
        {
            var aula = await _service.ObterPorIdAsync(id, ct);
            if (aula == null) return NotFound();

            return Ok(aula);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InserirAulaDTO dto, CancellationToken ct)
        {
            var resultado = await _service.CriarAsync(dto, ct);
            if (!resultado.Sucesso) return BadRequest(resultado.Mensagem);

            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Aula!.Id }, resultado.Aula);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarAulaDTO dto, CancellationToken ct)
        {
            var resultado = await _service.AtualizarAsync(id, dto, ct);
            if (!resultado.Sucesso) return NotFound(resultado.Mensagem);

            return Ok(resultado.Aula);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken ct)
        {
            var resultado = await _service.RemoverAsync(id, ct);
            if (!resultado.Sucesso) return NotFound(resultado.Mensagem);

            return NoContent();
        }
    }
}
