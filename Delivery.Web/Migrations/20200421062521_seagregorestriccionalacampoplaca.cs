using Microsoft.EntityFrameworkCore.Migrations;

namespace Delivery.Web.Migrations
{
    public partial class seagregorestriccionalacampoplaca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Repartidores_Placa",
                table: "Repartidores",
                column: "Placa",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Repartidores_Placa",
                table: "Repartidores");
        }
    }
}
