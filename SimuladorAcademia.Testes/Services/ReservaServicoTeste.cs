using FluentAssertions;
using Moq;
using SimuladorAcademia.Aplicacao.DTOs;
using SimuladorAcademia.Aplicacao.Servicos;
using SimuladorAcademia.Dominio.Contratos;
using SimuladorAcademia.Dominio.Entidades;
using SimuladorAcademia.Dominio.Enums;

namespace SimuladorAcademia.Tests.Services
{
    public class ReservaServicoTests
    {
        private readonly Mock<IReservaRepositorio> _mockRepositorio;
        private readonly ReservaServico _servico;

        public ReservaServicoTests()
        {
            _mockRepositorio = new Mock<IReservaRepositorio>();
            _servico = new ReservaServico(_mockRepositorio.Object);
        }

        [Fact]
        public async Task CriarReserva_DeveCriarComSucesso()
        {
            var alunoId = Guid.NewGuid();
            var aulaId = Guid.NewGuid();
            var dto = new InserirReservaDTO(alunoId, aulaId);

            _mockRepositorio
                .Setup(r => r.ExisteReservaAsync(alunoId, aulaId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _mockRepositorio
                .Setup(r => r.InserirAsync(It.IsAny<Reserva>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mockRepositorio
                .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Guid id, CancellationToken ct) => new Reserva
                {
                    Id = id,
                    AlunoId = alunoId,
                    AulaId = aulaId,
                    Aluno = new Aluno { Nome = "AlunoTeste" },
                    Aula = new Aula
                    {
                        Id = aulaId,
                        TipoDeAula = new TipoDeAula { Nome = "AulaTeste" },
                        DataAgendamento = DateTime.UtcNow,
                        DuracaoEmMinutos = 60,
                        CapacidadeMaxima = 20,
                        Participantes = 0,
                        IsAtivo = true,
                        IsCancelado = false
                    },
                    DataAgendamento = DateTime.UtcNow,
                    StatusReserva = StatusReserva.Agendado
                });


            var resultado = await _servico.CriarAsync(dto);

            resultado.Sucesso.Should().BeTrue();
            resultado.Mensagem.Should().Be("Reserva criada com sucesso.");
            resultado.Reserva.Should().NotBeNull();
            resultado.Reserva!.NomeAluno.Should().Be("AlunoTeste");
            resultado.Reserva.NomeAula.Should().Be("AulaTeste");
        }

        [Fact]
        public async Task CriarReserva_DeveFalharSeReservaDuplicada()
        {
            var alunoId = Guid.NewGuid();
            var aulaId = Guid.NewGuid();
            var dto = new InserirReservaDTO(alunoId, aulaId);

            _mockRepositorio
                .Setup(r => r.ExisteReservaAsync(alunoId, aulaId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var resultado = await _servico.CriarAsync(dto);

            resultado.Sucesso.Should().BeFalse();
            resultado.Mensagem.Should().Be("O aluno já possui uma reserva para esta aula.");
            resultado.Reserva.Should().BeNull();
        }
    }
}
