using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farabeh.MyBuilding.Api.Infra.Data.Sql.Migrations
{
    /// <inheritdoc />
    public partial class _101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Buildings",
                newName: "Mobile");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Buildings");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Buildings",
                newName: "Desc");
        }
    }
}
