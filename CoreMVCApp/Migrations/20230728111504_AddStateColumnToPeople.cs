using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddStateColumnToPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateID",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "StateID",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
