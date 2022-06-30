using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoachingApp.Migrations
{
    public partial class AddedAcceptDateforbothsubtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_coach",
                table: "Workout");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Sets_coach",
                table: "WorkoutSets");

            migrationBuilder.AlterColumn<int>(
                name: "coachID",
                table: "WorkoutSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "coachID",
                table: "Workout",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "acceptDate",
                table: "Client_WSub",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "acceptDate",
                table: "Client_NSub",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_coach",
                table: "Workout",
                column: "coachID",
                principalTable: "Coach",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Sets_coach",
                table: "WorkoutSets",
                column: "coachID",
                principalTable: "Coach",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_coach",
                table: "Workout");

            migrationBuilder.DropForeignKey(
                name: "FK_Workout_Sets_coach",
                table: "WorkoutSets");

            migrationBuilder.DropColumn(
                name: "acceptDate",
                table: "Client_WSub");

            migrationBuilder.DropColumn(
                name: "acceptDate",
                table: "Client_NSub");

            migrationBuilder.AlterColumn<int>(
                name: "coachID",
                table: "WorkoutSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "coachID",
                table: "Workout",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_coach",
                table: "Workout",
                column: "coachID",
                principalTable: "Coach",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_Sets_coach",
                table: "WorkoutSets",
                column: "coachID",
                principalTable: "Coach",
                principalColumn: "id");
        }
    }
}
