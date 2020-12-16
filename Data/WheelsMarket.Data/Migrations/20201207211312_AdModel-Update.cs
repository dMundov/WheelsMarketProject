using Microsoft.EntityFrameworkCore.Migrations;

namespace WheelsMarket.Data.Migrations
{
    public partial class AdModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ads",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Ads",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Ads");
        }
    }
}
