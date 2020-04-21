using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Delivery.Web.Migrations
{
    public partial class AgregoViajesYdetalleViajes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    IdViaje = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    Origen = table.Column<string>(maxLength: 100, nullable: true),
                    Destino = table.Column<string>(maxLength: 100, nullable: true),
                    Calificacion = table.Column<float>(nullable: false),
                    OrigenLatitud = table.Column<double>(nullable: false),
                    OrigenLongitud = table.Column<double>(nullable: false),
                    DestinoLatitud = table.Column<double>(nullable: false),
                    DestinoLongitud = table.Column<double>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    RepartidorIdRepartidor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.IdViaje);
                    table.ForeignKey(
                        name: "FK_Viajes_Repartidores_RepartidorIdRepartidor",
                        column: x => x.RepartidorIdRepartidor,
                        principalTable: "Repartidores",
                        principalColumn: "IdRepartidor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleViajes",
                columns: table => new
                {
                    IdDetalleViaje = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    ViajeIdViaje = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleViajes", x => x.IdDetalleViaje);
                    table.ForeignKey(
                        name: "FK_DetalleViajes_Viajes_ViajeIdViaje",
                        column: x => x.ViajeIdViaje,
                        principalTable: "Viajes",
                        principalColumn: "IdViaje",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleViajes_ViajeIdViaje",
                table: "DetalleViajes",
                column: "ViajeIdViaje");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_RepartidorIdRepartidor",
                table: "Viajes",
                column: "RepartidorIdRepartidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleViajes");

            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}
