using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamersChat.Data.Migrations
{
    /// <inheritdoc />
    public partial class bigchanges101231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "PostImage",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostContent",
                table: "Posts",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PostComments",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "PostComments",
                newName: "Content");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_UserId",
                table: "PostComments",
                newName: "IX_PostComments_userId");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "PostComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_AspNetUsers_userId",
                table: "PostComments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_AspNetUsers_userId",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "PostContent");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "PostComments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "PostComments",
                newName: "CommentContent");

            migrationBuilder.RenameIndex(
                name: "IX_PostComments_userId",
                table: "PostComments",
                newName: "IX_PostComments_UserId");

            migrationBuilder.AddColumn<string>(
                name: "PostImage",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "PostComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_AspNetUsers_UserId",
                table: "PostComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_Posts_PostId",
                table: "PostComments",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
