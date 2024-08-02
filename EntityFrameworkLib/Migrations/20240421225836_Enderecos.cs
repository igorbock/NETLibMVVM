using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EntityFrameworkLib.Migrations
{
    public partial class Enderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pessoas");

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rua = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<int>(nullable: true),
                    Cidade = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_IdEndereco",
                table: "Pessoas",
                column: "IdEndereco");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Enderecos_IdEndereco",
                table: "Pessoas",
                column: "IdEndereco",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Enderecos_IdEndereco",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_IdEndereco",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pessoas",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
