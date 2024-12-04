using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_Society_API.Migrations
{
    public partial class AddVoteInMyDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Books_BookId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_Users_UserId",
                table: "Vote");

            migrationBuilder.DropForeignKey(
                name: "FK_Vote_VotingSessions_VotingSessionId",
                table: "Vote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vote",
                table: "Vote");

            migrationBuilder.RenameTable(
                name: "Vote",
                newName: "Votes");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_VotingSessionId",
                table: "Votes",
                newName: "IX_Votes_VotingSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vote_BookId",
                table: "Votes",
                newName: "IX_Votes_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Votes",
                columns: new[] { "Id", "BookId", "UserId", "VotingSessionId" },
                values: new object[,]
                {
                    { 1, 101, 1, 1 },
                    { 2, 102, 2, 1 },
                    { 3, 103, 3, 1 },
                    { 4, 104, 2, 2 },
                    { 5, 105, 4, 2 },
                    { 6, 106, 5, 2 },
                    { 7, 107, 3, 3 },
                    { 8, 108, 6, 3 },
                    { 9, 109, 4, 4 },
                    { 10, 110, 7, 4 },
                    { 11, 111, 5, 5 },
                    { 12, 112, 8, 5 },
                    { 13, 113, 6, 6 },
                    { 14, 114, 9, 6 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Books_BookId",
                table: "Votes",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_VotingSessions_VotingSessionId",
                table: "Votes",
                column: "VotingSessionId",
                principalTable: "VotingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Books_BookId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_VotingSessions_VotingSessionId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Votes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "Vote");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_VotingSessionId",
                table: "Vote",
                newName: "IX_Vote_VotingSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "Vote",
                newName: "IX_Vote_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_BookId",
                table: "Vote",
                newName: "IX_Vote_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vote",
                table: "Vote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Books_BookId",
                table: "Vote",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_Users_UserId",
                table: "Vote",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vote_VotingSessions_VotingSessionId",
                table: "Vote",
                column: "VotingSessionId",
                principalTable: "VotingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
