using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racen.Fun.Website.Migrations
{
    /// <inheritdoc />
    public partial class AddTiers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "ContactModels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tier",
                table: "ContactModels");
        }
    }
}
