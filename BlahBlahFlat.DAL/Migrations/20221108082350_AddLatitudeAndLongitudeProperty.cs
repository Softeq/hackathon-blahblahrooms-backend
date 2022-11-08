using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlahBlahFlat.DAL.Migrations
{
    public partial class AddLatitudeAndLongitudeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinates",
                table: "Placements",
                newName: "Longitude");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Placements",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Placements");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Placements",
                newName: "Coordinates");
        }
    }
}
