using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBlazorCRUDOperationsWithDotNet8.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
