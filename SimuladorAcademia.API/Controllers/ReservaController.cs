using Microsoft.AspNetCore.Mvc;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;

namespace SimuladorAcademia.API.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServico _service;

        public ReservaController(IReservaServico service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos([FromQuery] RequisicaoPaginada requisicao, CancellationToken cancellationToken)
        {
            var reservas = await _service.ObterTodosAsync(requisicao, cancellationToken);
            return Ok(reservas);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id, CancellationToken cancellationToken)
        {
            var reserva = await _service.ObterPorIdAsync(id, cancellationToken);
            if (reserva == null) return NotFound();

            return Ok(reserva);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InserirReservaDTO dto, CancellationToken cancellationToken)
        {
            var criado = await _service.CriarAsync(dto, cancellationToken);
            if (!criado.Sucesso) return BadRequest(criado.Mensagem);

            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Reserva!.Id }, criado.Reserva);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken cancellationToken)
        {
            var removido = await _service.RemoverAsync(id, cancellationToken);
            if (!removido.Sucesso) return NotFound(removido.Mensagem);

            return NoContent();
        }
    }
}
