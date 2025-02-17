using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookworm_Society_API.Migrations
{
    public partial class BookModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Harper", "Lee" },
                    { 2, "J.R.R.", "Tolkien" },
                    { 3, "Frank", "Herbert" },
                    { 4, "Gillian", "Flynn" },
                    { 5, "Jane", "Austen" },
                    { 6, "Markus", "Zusak" },
                    { 7, "Stieg", "Larsson" },
                    { 8, "Shirley", "Jackson" },
                    { 9, "Paulo", "Coelho" },
                    { 10, "Bram", "Stoker" },
                    { 11, "J.D.", "Salinger" },
                    { 12, "Cormac", "McCarthy" },
                    { 13, "J.K.", "Rowling" },
                    { 14, "George", "Orwell" },
                    { 15, "F. Scott", "Fitzgerald" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Historical Fiction" },
                    { 2, "Fantasy" },
                    { 3, "Science Fiction" },
                    { 4, "Mystery" },
                    { 5, "Romance" },
                    { 6, "Thriller" },
                    { 7, "Horror" },
                    { 8, "Slice of Life" },
                    { 9, "Drama" },
                    { 10, "Adventure" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 1, 1, "https://m.media-amazon.com/images/I/81aY1lxk+9L._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 2, 2, "https://m.media-amazon.com/images/I/71mK6W2wMrL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 3, 3, "https://m.media-amazon.com/images/I/71+IVP4wnEL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 4, 4, "https://m.media-amazon.com/images/I/61mcHA1yJLL._SL1141_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 5, 5, "https://m.media-amazon.com/images/I/51zkOaWMu7S._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 6, 1, "https://m.media-amazon.com/images/I/914cHl9v7oL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 7, 6, "https://m.media-amazon.com/images/I/51rKlSld33L.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 8, 7, "https://m.media-amazon.com/images/I/81HAeHFZ9oL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 9, 8, "https://m.media-amazon.com/images/I/71zHDXu1TaL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 10, 7, "https://m.media-amazon.com/images/I/71dGP-WQ0HL._SL1499_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 11, 9, "https://m.media-amazon.com/images/I/71nXPGovoTL._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 12, 10, "https://m.media-amazon.com/images/I/51M7XGLQTBL._SL1200_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 13, 2, "https://m.media-amazon.com/images/I/91A6EgLH+2L._SL1500_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 14, 3, "https://m.media-amazon.com/images/I/51A9t9irmEL._SY445_SX342_.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "AuthorId", "GenreId", "ImageUrl" },
                values: new object[] { 15, 9, "https://m.media-amazon.com/images/I/61PxxqzdJPL._SL1491_.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Author_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenreId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Harper Lee", "Historical Fiction", "https://example.com/mock.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "J.R.R. Tolkien", "Fantasy", "https://example.com/hobbit.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Frank Herbert", "Science Fiction", "https://example.com/dune.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Gillian Flynn", "Mystery", "https://example.com/gonegirl.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Jane Austen", "Romance", "https://example.com/pride.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Markus Zusak", "Historical Fiction", "https://example.com/thief.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Stieg Larsson", "Thriller", "https://example.com/dragon.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Shirley Jackson", "Horror", "https://example.com/hillhouse.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Paulo Coelho", "Slice of Life", "https://example.com/alchemist.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Bram Stoker", "Horror", "https://example.com/dracula.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "J.D. Salinger", "Drama", "https://example.com/catcher.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "Cormac McCarthy", "Adventure", "https://example.com/road.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "J.K. Rowling", "Fantasy", "https://example.com/harry.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "George Orwell", "Science Fiction", "https://example.com/1984.jpg" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "Author", "Genre", "ImageUrl" },
                values: new object[] { "F. Scott Fitzgerald", "Drama", "https://example.com/gatsby.jpg" });
        }
    }
}
