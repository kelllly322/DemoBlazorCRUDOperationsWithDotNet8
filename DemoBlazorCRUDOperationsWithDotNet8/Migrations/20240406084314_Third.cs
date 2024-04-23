using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBlazorCRUDOperationsWithDotNet8.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DidOrDidntTakenMedicine",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfEachDosage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SymptomDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "DidOrDidntTakeMedicine",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DidOrDidntTakeMedicine",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "UnitOfEachDosage",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "SymptomDescription",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DidOrDidntTakenMedicine",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
