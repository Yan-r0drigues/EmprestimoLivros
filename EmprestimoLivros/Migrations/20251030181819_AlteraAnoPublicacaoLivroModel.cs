using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivros.Migrations
{
    /// <inheritdoc />
    public partial class AlteraAnoPublicacaoLivroModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnoPublicacao",
                table: "Livros");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPublicacao",
                table: "Livros",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPublicacao",
                table: "Livros");

            migrationBuilder.AddColumn<int>(
                name: "AnoPublicacao",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
