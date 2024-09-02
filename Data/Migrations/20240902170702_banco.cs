using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class banco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnexosOutros",
                table: "anexo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Assinatura",
                table: "anexo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "AssinaturaPdf",
                table: "anexo",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Orcamento",
                table: "anexo",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "OrcamentoProjeto",
                table: "anexo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "OutrosAnexos",
                table: "anexo",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "PDFPlanta",
                table: "anexo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnexosOutros",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "Assinatura",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "AssinaturaPdf",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "Orcamento",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "OrcamentoProjeto",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "OutrosAnexos",
                table: "anexo");

            migrationBuilder.DropColumn(
                name: "PDFPlanta",
                table: "anexo");
        }
    }
}
