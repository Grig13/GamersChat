using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersChat.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateuserdto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersDTO",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "ApplicationUsersDTO");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicationUsersDTO",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "ApplicationUsersDTO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersDTO",
                table: "ApplicationUsersDTO",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsersDTO",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "City",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ApplicationUsersDTO");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "ApplicationUsersDTO");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ApplicationUsersDTO",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ApplicationUsersDTO",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "ApplicationUsersDTO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsersDTO",
                table: "ApplicationUsersDTO",
                column: "Id");
        }
    }
}
