using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimuladorAcademia.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposAula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IsAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApagadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    LimiteAula = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApagadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TipoDeAulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "INTEGER", nullable: false),
                    CapacidadeMaxima = table.Column<int>(type: "INTEGER", nullable: false),
                    Participantes = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsCancelado = table.Column<bool>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApagadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aulas_TiposAula_TipoDeAulaId",
                        column: x => x.TipoDeAulaId,
                        principalTable: "TiposAula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true),
                    TipoDePlanoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsAtivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ContagemDeAulasMensais = table.Column<int>(type: "INTEGER", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApagadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_TiposPlano_TipoDePlanoId",
                        column: x => x.TipoDePlanoId,
                        principalTable: "TiposPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StatusReserva = table.Column<int>(type: "INTEGER", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CanceladoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ApagadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosReserva",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReservaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlunoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MotivoCancelamento = table.Column<string>(type: "TEXT", nullable: true),
                    ModificadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    ModificadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosReserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricosReserva_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_Email_Nome",
                table: "Alunos",
                columns: new[] { "Email", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TipoDePlanoId",
                table: "Alunos",
                column: "TipoDePlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_TipoDeAulaId",
                table: "Aulas",
                column: "TipoDeAulaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosReserva_ReservaId",
                table: "HistoricosReserva",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AlunoId_AulaId",
                table: "Reservas",
                columns: new[] { "AlunoId", "AulaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AulaId",
                table: "Reservas",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposAula_Nome",
                table: "TiposAula",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposPlano_Nome",
                table: "TiposPlano",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricosReserva");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "TiposPlano");

            migrationBuilder.DropTable(
                name: "TiposAula");
        }
    }
}
