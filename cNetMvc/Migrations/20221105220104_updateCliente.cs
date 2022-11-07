using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cNetMvc.Migrations
{
    public partial class updateCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "cliente");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "cliente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "cliente",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "dataNascimento",
                table: "cliente",
                newName: "data_nascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Clientes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "data_nascimento",
                table: "Clientes",
                newName: "dataNascimento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "id");
        }
    }
}
