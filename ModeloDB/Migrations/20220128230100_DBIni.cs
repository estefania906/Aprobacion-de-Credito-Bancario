using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDB.Migrations
{
    public partial class DBIni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "garante",
                columns: table => new
                {
                    GaranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGarante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoGarante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaGarante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoGarante = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garante", x => x.GaranteId);
                });

            migrationBuilder.CreateTable(
                name: "vigencia",
                columns: table => new
                {
                    VigenciaTasaAnualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tasa_anual = table.Column<double>(type: "float", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vigencia", x => x.VigenciaTasaAnualId);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GaranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_cliente_garante_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "garante",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "garante_det",
                columns: table => new
                {
                    GaranteDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GaranteId = table.Column<int>(type: "int", nullable: false),
                    AvaluoBienParticular = table.Column<double>(type: "float", nullable: false),
                    Deuda_otros_bancos = table.Column<double>(type: "float", nullable: false),
                    Gastos_garante = table.Column<double>(type: "float", nullable: false),
                    ingreso_mensual_garante = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garante_det", x => x.GaranteDetId);
                    table.ForeignKey(
                        name: "FK_garante_det_garante_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "garante",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historial_garante",
                columns: table => new
                {
                    HistorialGaranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuota = table.Column<double>(type: "float", nullable: false),
                    FechaPagoReal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPagoSolicitada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadPagada = table.Column<double>(type: "float", nullable: false),
                    CantidadSolicitada = table.Column<double>(type: "float", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    DiasRetrasoGarante = table.Column<int>(type: "int", nullable: false),
                    GaranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_garante", x => x.HistorialGaranteId);
                    table.ForeignKey(
                        name: "FK_historial_garante_garante_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "garante",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configuracion",
                columns: table => new
                {
                    VigenciaTasaAnualId = table.Column<int>(type: "int", nullable: false),
                    meses_tope = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_configuracion_vigencia_VigenciaTasaAnualId",
                        column: x => x.VigenciaTasaAnualId,
                        principalTable: "vigencia",
                        principalColumn: "VigenciaTasaAnualId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cliente_det",
                columns: table => new
                {
                    ClienteDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    AvaluoBienParticular = table.Column<double>(type: "float", nullable: false),
                    Deuda_otros_bancos = table.Column<double>(type: "float", nullable: false),
                    Gastos_cliente = table.Column<double>(type: "float", nullable: false),
                    ingreso_mensual_cliente = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente_det", x => x.ClienteDetId);
                    table.ForeignKey(
                        name: "FK_cliente_det_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historial_cliente",
                columns: table => new
                {
                    HistorialClienteId = table.Column<int>(type: "int", nullable: false),
                    NumeroCuota = table.Column<double>(type: "float", nullable: false),
                    FechaPagoReal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaPagoSolicitada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantidadPagada = table.Column<double>(type: "float", nullable: false),
                    CantidadSolicitada = table.Column<double>(type: "float", nullable: false),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    DiasRetrasoCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_cliente", x => x.HistorialClienteId);
                    table.ForeignKey(
                        name: "FK_historial_cliente_cliente_HistorialClienteId",
                        column: x => x.HistorialClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "costo_cuota",
                columns: table => new
                {
                    CostoCuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalculoCuota = table.Column<double>(type: "float", nullable: false),
                    CalculoAmortizacion = table.Column<double>(type: "float", nullable: false),
                    TasaAnual = table.Column<double>(type: "float", nullable: false),
                    InteresMensual = table.Column<double>(type: "float", nullable: false),
                    CalculoPagoTotal = table.Column<double>(type: "float", nullable: false),
                    MontoSolicitado = table.Column<double>(type: "float", nullable: false),
                    NumeroCuotas = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    VigenciaTasaAnaulId = table.Column<int>(type: "int", nullable: false),
                    Cliente_DetClienteDetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costo_cuota", x => x.CostoCuotaId);
                    table.ForeignKey(
                        name: "FK_costo_cuota_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_costo_cuota_cliente_det_Cliente_DetClienteDetId",
                        column: x => x.Cliente_DetClienteDetId,
                        principalTable: "cliente_det",
                        principalColumn: "ClienteDetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_costo_cuota_vigencia_VigenciaTasaAnaulId",
                        column: x => x.VigenciaTasaAnaulId,
                        principalTable: "vigencia",
                        principalColumn: "VigenciaTasaAnualId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "validaciones",
                columns: table => new
                {
                    ValidacionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    val_patrimonio_cliente = table.Column<bool>(type: "bit", nullable: false),
                    val_patrimonio_garante = table.Column<bool>(type: "bit", nullable: false),
                    val_comportamiento_cliente = table.Column<bool>(type: "bit", nullable: false),
                    val_comportamiento_garante = table.Column<bool>(type: "bit", nullable: false),
                    val_historial_cliente = table.Column<bool>(type: "bit", nullable: false),
                    val_historial_garante = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    GaranteId = table.Column<int>(type: "int", nullable: false),
                    HistorialClienteId = table.Column<int>(type: "int", nullable: false),
                    HistorialGaranteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_validaciones", x => x.ValidacionesId);
                    table.ForeignKey(
                        name: "FK_validaciones_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_validaciones_garante_GaranteId",
                        column: x => x.GaranteId,
                        principalTable: "garante",
                        principalColumn: "GaranteId");
                    table.ForeignKey(
                        name: "FK_validaciones_historial_cliente_HistorialClienteId",
                        column: x => x.HistorialClienteId,
                        principalTable: "historial_cliente",
                        principalColumn: "HistorialClienteId");
                    table.ForeignKey(
                        name: "FK_validaciones_historial_garante_HistorialGaranteId",
                        column: x => x.HistorialGaranteId,
                        principalTable: "historial_garante",
                        principalColumn: "HistorialGaranteId");
                });

            migrationBuilder.CreateTable(
                name: "credito",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CostoCuotaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credito", x => new { x.ClienteId, x.CostoCuotaId });
                    table.ForeignKey(
                        name: "FK_credito_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_credito_costo_cuota_CostoCuotaId",
                        column: x => x.CostoCuotaId,
                        principalTable: "costo_cuota",
                        principalColumn: "CostoCuotaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_GaranteId",
                table: "cliente",
                column: "GaranteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_det_ClienteId",
                table: "cliente_det",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_configuracion_VigenciaTasaAnualId",
                table: "configuracion",
                column: "VigenciaTasaAnualId");

            migrationBuilder.CreateIndex(
                name: "IX_costo_cuota_Cliente_DetClienteDetId",
                table: "costo_cuota",
                column: "Cliente_DetClienteDetId");

            migrationBuilder.CreateIndex(
                name: "IX_costo_cuota_ClienteId",
                table: "costo_cuota",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_costo_cuota_VigenciaTasaAnaulId",
                table: "costo_cuota",
                column: "VigenciaTasaAnaulId");

            migrationBuilder.CreateIndex(
                name: "IX_credito_CostoCuotaId",
                table: "credito",
                column: "CostoCuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_garante_det_GaranteId",
                table: "garante_det",
                column: "GaranteId");

            migrationBuilder.CreateIndex(
                name: "IX_historial_garante_GaranteId",
                table: "historial_garante",
                column: "GaranteId");

            migrationBuilder.CreateIndex(
                name: "IX_validaciones_ClienteId",
                table: "validaciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_validaciones_GaranteId",
                table: "validaciones",
                column: "GaranteId");

            migrationBuilder.CreateIndex(
                name: "IX_validaciones_HistorialClienteId",
                table: "validaciones",
                column: "HistorialClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_validaciones_HistorialGaranteId",
                table: "validaciones",
                column: "HistorialGaranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracion");

            migrationBuilder.DropTable(
                name: "credito");

            migrationBuilder.DropTable(
                name: "garante_det");

            migrationBuilder.DropTable(
                name: "validaciones");

            migrationBuilder.DropTable(
                name: "costo_cuota");

            migrationBuilder.DropTable(
                name: "historial_cliente");

            migrationBuilder.DropTable(
                name: "historial_garante");

            migrationBuilder.DropTable(
                name: "cliente_det");

            migrationBuilder.DropTable(
                name: "vigencia");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "garante");
        }
    }
}
