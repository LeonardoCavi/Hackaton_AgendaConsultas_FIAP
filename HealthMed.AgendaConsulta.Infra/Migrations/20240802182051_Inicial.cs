using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.AgendaConsulta.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    NumeroCRM = table.Column<string>(type: "VARCHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicoCredencial",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoCredencial", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_MedicoCredencial_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoHorarioExpediente",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    TrabalhaDomingo = table.Column<bool>(type: "BIT", nullable: false),
                    InicioDomingo = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimDomingo = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaSegunda = table.Column<bool>(type: "BIT", nullable: false),
                    InicioSegunda = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimSegunda = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaTerca = table.Column<bool>(type: "BIT", nullable: false),
                    InicioTerca = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimTerca = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaQuarta = table.Column<bool>(type: "BIT", nullable: false),
                    InicioQuarta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimQuarta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaQuinta = table.Column<bool>(type: "BIT", nullable: false),
                    InicioQuinta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimQuinta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaSexta = table.Column<bool>(type: "BIT", nullable: false),
                    InicioSexta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimSexta = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    TrabalhaSabado = table.Column<bool>(type: "BIT", nullable: false),
                    InicioSabado = table.Column<TimeOnly>(type: "TIME", nullable: false),
                    FimSabado = table.Column<TimeOnly>(type: "TIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoHorarioExpediente", x => x.MedicoId);
                    table.ForeignKey(
                        name: "FK_MedicoHorarioExpediente_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Fim = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteCredencial",
                columns: table => new
                {
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteCredencial", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_PacienteCredencial_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoId",
                table: "Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "MedicoCredencial");

            migrationBuilder.DropTable(
                name: "MedicoHorarioExpediente");

            migrationBuilder.DropTable(
                name: "PacienteCredencial");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
