using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicenciasMedicasGL.Migracion
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicenciaId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false),
                    FechaYHoraVisita = table.Column<DateTimeOffset>(nullable: false),
                    FechaInicio = table.Column<DateTimeOffset>(nullable: false),
                    FechaFin = table.Column<DateTimeOffset>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true),
                    Justificada = table.Column<bool>(nullable: false),
                    CantidadDias = table.Column<int>(nullable: false),
                    Nota = table.Column<string>(maxLength: 200, nullable: false),
                    Cargada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licencias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(nullable: false),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    EmpleadoId = table.Column<int>(nullable: false),
                    VisitaId = table.Column<int>(nullable: false),
                    FechaInicioSolicitada = table.Column<DateTime>(nullable: false),
                    FechaFinSolicitada = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Activa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    TipoTelefono = table.Column<int>(nullable: false),
                    PersonaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestadoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    TelefonoContactoId = table.Column<int>(nullable: true),
                    EmailContacto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestadoras_Telefonos_TelefonoContactoId",
                        column: x => x.TelefonoContactoId,
                        principalTable: "Telefonos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    ObraSocial = table.Column<int>(nullable: false),
                    TelefonoId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Legajo = table.Column<string>(maxLength: 100, nullable: true),
                    LicenciaId = table.Column<int>(nullable: true),
                    estaActivo = table.Column<bool>(nullable: true),
                    Matricula = table.Column<string>(maxLength: 12, nullable: true),
                    PestadoraId = table.Column<int>(nullable: true),
                    PrestadoraId = table.Column<int>(nullable: true),
                    Medico_LicenciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Prestadoras_PrestadoraId",
                        column: x => x.PrestadoraId,
                        principalTable: "Prestadoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licencias_EmpleadoId",
                table: "Licencias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencias_MedicoId",
                table: "Licencias",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PrestadoraId",
                table: "Personas",
                column: "PrestadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadoras_TelefonoContactoId",
                table: "Prestadoras",
                column: "TelefonoContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_PersonaId",
                table: "Telefonos",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_LicenciaId",
                table: "Visitas",
                column: "LicenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_MedicoId",
                table: "Visitas",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Personas_MedicoId",
                table: "Visitas",
                column: "MedicoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Licencias_LicenciaId",
                table: "Visitas",
                column: "LicenciaId",
                principalTable: "Licencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Licencias_Personas_EmpleadoId",
                table: "Licencias",
                column: "EmpleadoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Licencias_Personas_MedicoId",
                table: "Licencias",
                column: "MedicoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefonos_Personas_PersonaId",
                table: "Telefonos",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefonos_Personas_PersonaId",
                table: "Telefonos");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Licencias");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestadoras");

            migrationBuilder.DropTable(
                name: "Telefonos");
        }
    }
}
