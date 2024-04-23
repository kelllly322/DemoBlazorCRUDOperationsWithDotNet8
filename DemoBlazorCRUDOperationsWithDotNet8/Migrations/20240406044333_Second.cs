using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoBlazorCRUDOperationsWithDotNet8.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "UnitOfEachDosage");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Operator");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "DidOrDidntTakenMedicine",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EachDosage",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Instruction",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicineName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OperationTime",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "SymptomDescription",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DidOrDidntTakenMedicine",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EachDosage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Instruction",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MedicineName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OperationTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SymptomDescription",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitOfEachDosage",
                table: "Products",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Operator",
                table: "Products",
                newName: "Name");
        }
    }
}
