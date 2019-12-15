using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotel.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnuncioWebmotors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataEdicao = table.Column<DateTime>(nullable: true),
                    DataExclusao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 255, nullable: false),
                    Avaliacao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Rua = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<string>(maxLength: 9, nullable: false),
                    CEP = table.Column<string>(maxLength: 20, nullable: false),
                    Estado = table.Column<string>(maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Comodidades = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnuncioWebmotors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnuncioWebmotors");
        }
    }
}
