using Microsoft.AspNetCore.Mvc;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.DTOs.Geral;
using SimuladorAcademia.Aplicacao.Interfaces;

namespace SimuladorAcademia.API.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServico _service;

        public AlunoController(IAlunoServico service)
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
            var aluno = await _service.ObterPorIdAsync(id, ct);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] InserirAlunoDTO dto, CancellationToken ct)
        {
            var resultado = await _service.CriarAsync(dto, ct);
            if (!resultado.Sucesso)
                return StatusCode(500, resultado.Mensagem);

            return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Aluno!.Id }, resultado.Aluno);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarAlunoDTO dto, CancellationToken ct)
        {
            var resultado = await _service.AtualizarAsync(id, dto, ct);
            if (!resultado.Sucesso)
                return StatusCode(500, resultado.Mensagem);

            return Ok(resultado.Aluno);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Deletar(Guid id, CancellationToken ct)
        {
            var resultado = await _service.RemoverAsync(id, ct);
            if (!resultado.Sucesso)
                return StatusCode(500, resultado.Mensagem);

            return NoContent();
        }
    }
}
