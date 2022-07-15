using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingApp.Migrations
{
    public partial class mansodanso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Client_WSub_coachID",
                table: "Client_WSub",
                column: "coachID");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_WSub_Coach_coachID",
                table: "Client_WSub",
                column: "coachID",
                principalTable: "Coach",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_WSub_Coach_coachID",
                table: "Client_WSub");

            migrationBuilder.DropIndex(
                name: "IX_Client_WSub_coachID",
                table: "Client_WSub");
        }
    }
}
