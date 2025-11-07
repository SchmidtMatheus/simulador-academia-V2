using Microsoft.AspNetCore.Mvc;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Dominio.Contratos;

namespace SimuladorAcademia.API.Controllers
{
    [ApiController]
    [Route("api/tipo-de-aula")]
    public class TipoDeAulaController : ControllerBase
    {
        private readonly ITipoDeAulaServico _service;

        public TipoDeAulaController(ITipoDeAulaServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken)
        {
            var tipos = await _service.ObterTodosAsync(cancellationToken);
            return Ok(tipos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var tipo = await _service.ObterPorIdAsync(id, cancellationToken);
            if (tipo == null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InserirTipoDeAulaDTO tipo, CancellationToken cancellationToken)
        {
            var criado = await _service.CriarAsync(tipo, cancellationToken);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Tipo!.Id }, criado);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarTipoDeAulaDTO tipo, CancellationToken cancellationToken)
        {
            var atualizado = await _service.AtualizarAsync(id, tipo, cancellationToken);
            if (atualizado.Sucesso == false)
                return StatusCode(500, atualizado.Mensagem);

            return StatusCode(500, atualizado.Mensagem);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken cancellationToken)
        {
            var removido = await _service.RemoverAsync(id, cancellationToken);
            if (removido.Sucesso == false)
                return StatusCode(500, removido.Mensagem);

            return NoContent();
        }
    }
}
