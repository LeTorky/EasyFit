using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingApp.Migrations
{
    public partial class Added_About_In_Coach_Removed_Email_From_Coach_And_Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Client");

            migrationBuilder.AddColumn<string>(
                name: "about",
                table: "Coach",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "about",
                table: "Coach");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Coach",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
