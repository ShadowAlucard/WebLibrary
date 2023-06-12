using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_DB.Migrations
{
    public partial class Second_ExtendedWithConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReaderNumber",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Loans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Books",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ReaderNumber",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
