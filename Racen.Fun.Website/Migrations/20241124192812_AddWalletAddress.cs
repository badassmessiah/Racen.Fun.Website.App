using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Racen.Fun.Website.Migrations
{
    /// <inheritdoc />
    public partial class AddWalletAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "ContactModels",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "WalletAddress",
                table: "ContactModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletAddress",
                table: "ContactModels");

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "ContactModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
