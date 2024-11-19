using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookworm_Society_API.Migrations
{
    public partial class UpdateModelSnapshot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Author = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MeetUpType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HostId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookClubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookClubs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookClubs_Users_HostId",
                        column: x => x.HostId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookClubsHaveReadBook",
                columns: table => new
                {
                    BookClubsId = table.Column<int>(type: "integer", nullable: false),
                    HaveReadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookClubsHaveReadBook", x => new { x.BookClubsId, x.HaveReadId });
                    table.ForeignKey(
                        name: "FK_BookClubsHaveReadBook_BookClubs_BookClubsId",
                        column: x => x.BookClubsId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookClubsHaveReadBook_Books_HaveReadId",
                        column: x => x.HaveReadId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false),
                    IsEdited = table.Column<bool>(type: "boolean", nullable: false),
                    BookClubId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_BookClubs_BookClubId",
                        column: x => x.BookClubId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookClubMembership",
                columns: table => new
                {
                    MemberBookClubsId = table.Column<int>(type: "integer", nullable: false),
                    MembersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookClubMembership", x => new { x.MemberBookClubsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_UserBookClubMembership_BookClubs_MemberBookClubsId",
                        column: x => x.MemberBookClubsId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBookClubMembership_Users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    VotingStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VotingEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WinningBookId = table.Column<int>(type: "integer", nullable: true),
                    BookClubId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VotingSessions_BookClubs_BookClubId",
                        column: x => x.BookClubId,
                        principalTable: "BookClubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingSessions_Books_WinningBookId",
                        column: x => x.WinningBookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    VotingSessionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_VotingSessions_VotingSessionId",
                        column: x => x.VotingSessionId,
                        principalTable: "VotingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VotingSessionBooks",
                columns: table => new
                {
                    VotingBooksId = table.Column<int>(type: "integer", nullable: false),
                    VotingSessionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VotingSessionBooks", x => new { x.VotingBooksId, x.VotingSessionsId });
                    table.ForeignKey(
                        name: "FK_VotingSessionBooks_Books_VotingBooksId",
                        column: x => x.VotingBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotingSessionBooks_VotingSessions_VotingSessionsId",
                        column: x => x.VotingSessionsId,
                        principalTable: "VotingSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 101, "Harper Lee", "A novel about the serious issues of rape and racial inequality.", "Historical Fiction", "https://example.com/mock.jpg", "To Kill a Mockingbird" },
                    { 102, "J.R.R. Tolkien", "A journey through Middle-earth with Bilbo Baggins.", "Fantasy", "https://example.com/hobbit.jpg", "The Hobbit" },
                    { 103, "Frank Herbert", "A science fiction epic about politics, religion, and survival on the desert planet Arrakis.", "Science Fiction", "https://example.com/dune.jpg", "Dune" },
                    { 104, "Gillian Flynn", "A psychological thriller about marriage and betrayal.", "Mystery", "https://example.com/gonegirl.jpg", "Gone Girl" },
                    { 105, "Jane Austen", "A romantic novel about the manners and matrimonial machinations of early 19th century England.", "Romance", "https://example.com/pride.jpg", "Pride and Prejudice" },
                    { 106, "Markus Zusak", "The story of a young girl who steals books in Nazi Germany.", "Historical Fiction", "https://example.com/thief.jpg", "The Book Thief" },
                    { 107, "Stieg Larsson", "A gripping thriller involving murder, mystery, and family secrets.", "Thriller", "https://example.com/dragon.jpg", "The Girl with the Dragon Tattoo" },
                    { 108, "Shirley Jackson", "A chilling tale of psychological horror and supernatural events.", "Horror", "https://example.com/hillhouse.jpg", "The Haunting of Hill House" },
                    { 109, "Paulo Coelho", "A tale of self-discovery and pursuing one's dreams.", "Slice of Life", "https://example.com/alchemist.jpg", "The Alchemist" },
                    { 110, "Bram Stoker", "The classic vampire novel about the infamous Count Dracula.", "Horror", "https://example.com/dracula.jpg", "Dracula" },
                    { 111, "J.D. Salinger", "A story about teenage rebellion and angst.", "Drama", "https://example.com/catcher.jpg", "The Catcher in the Rye" },
                    { 112, "Cormac McCarthy", "A post-apocalyptic novel about a father and son journeying through a devastated America.", "Adventure", "https://example.com/road.jpg", "The Road" },
                    { 113, "J.K. Rowling", "The beginning of Harry Potter's journey in the wizarding world.", "Fantasy", "https://example.com/harry.jpg", "Harry Potter and the Sorcerer's Stone" },
                    { 114, "George Orwell", "A dystopian novel about totalitarianism and surveillance.", "Science Fiction", "https://example.com/1984.jpg", "1984" },
                    { 115, "F. Scott Fitzgerald", "A critique of the American Dream in the Jazz Age.", "Drama", "https://example.com/gatsby.jpg", "The Great Gatsby" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "ImageUrl", "JoinedDate", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "Alice", "https://example.com/alice.jpg", new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "UID12345", "alicej" },
                    { 2, "Bob", "https://example.com/bob.jpg", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "UID67890", "bobsmith" },
                    { 3, "Charlie", "https://example.com/charlie.jpg", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", "UID24680", "charlieb" },
                    { 4, "Diana", "https://example.com/diana.jpg", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prince", "UID13579", "dianap" },
                    { 5, "Edward", "https://example.com/edward.jpg", new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elric", "UID11223", "edwarde" },
                    { 6, "Fiona", "https://example.com/fiona.jpg", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hill", "UID44556", "fionah" },
                    { 7, "George", "https://example.com/george.jpg", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrison", "UID77889", "georgeh" },
                    { 8, "Hannah", "https://example.com/hannah.jpg", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montana", "UID99101", "hannahm" },
                    { 9, "Ian", "https://example.com/ian.jpg", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Curtis", "UID22334", "ianc" },
                    { 10, "Jill", "https://example.com/jill.jpg", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentine", "UID55667", "jillv" },
                    { 11, "Kyle", "https://example.com/kyle.jpg", new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reese", "UID77880", "kyler" },
                    { 12, "Laura", "https://example.com/laura.jpg", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croft", "UID99112", "laurac" },
                    { 13, "Mike", "https://example.com/mike.jpg", new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tyson", "UID22344", "miket" },
                    { 14, "Nina", "https://example.com/nina.jpg", new DateTime(2022, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williams", "UID55678", "ninaw" },
                    { 15, "Oscar", "https://example.com/oscar.jpg", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilde", "UID77891", "oscarw" }
                });

            migrationBuilder.InsertData(
                table: "BookClubs",
                columns: new[] { "Id", "BookId", "DateCreated", "Description", "HostId", "ImageUrl", "MeetUpType", "Name" },
                values: new object[,]
                {
                    { 1, 101, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A club for avid readers of classic literature.", 1, "https://example.com/club1.jpg", "Online", "Literary Legends" },
                    { 2, 102, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Discussing all things fantasy and magical worlds.", 2, "https://example.com/club2.jpg", "In-Person", "Fantasy Fanatics" },
                    { 3, 103, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring science fiction novels and ideas.", 3, "https://example.com/club3.jpg", "Hybrid", "Sci-Fi Society" },
                    { 4, 104, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "For fans of thrilling mysteries and crime stories.", 4, "https://example.com/club4.jpg", "Online", "Mystery Maniacs" },
                    { 5, 105, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A group dedicated to the best romance novels.", 5, "https://example.com/club5.jpg", "In-Person", "Romance Readers" },
                    { 6, 106, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delve into historical fiction with fellow enthusiasts.", 6, "https://example.com/club6.jpg", "Online", "Historical Tales" },
                    { 7, 107, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intense thrillers and gripping reads every week.", 7, "https://example.com/club7.jpg", "Hybrid", "Thriller Thursdays" },
                    { 8, 108, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Exploring supernatural and paranormal fiction.", 8, "https://example.com/club8.jpg", "In-Person", "Supernatural Circle" },
                    { 9, 109, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heartwarming stories and everyday adventures.", 9, "https://example.com/club9.jpg", "Online", "Slice of Life" },
                    { 10, 110, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spooky tales and scary reads for brave souls.", 10, "https://example.com/club10.jpg", "Hybrid", "Horror House" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Content", "CreatedDate", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, 101, "An impactful story that captures the essence of justice and morality.", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 2, 102, "A magical adventure filled with charming characters and vivid landscapes.", new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 3, 103, "Intricate world-building and a gripping tale of power and survival.", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 4, 104, "Twists and turns that keep you guessing until the very end.", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 5, 105, "A delightful exploration of love, class, and character in Regency England.", new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 6, 106, "A heart-wrenching yet inspiring story set during a dark time in history.", new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 7, 107, "Dark, gripping, and impossible to put down.", new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 8, 108, "A masterpiece of psychological horror that lingers with you.", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8 },
                    { 9, 109, "A simple yet profound story that inspires self-discovery and hope.", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 9 },
                    { 10, 110, "A chilling classic that set the standard for gothic horror.", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 10 },
                    { 11, 111, "Raw, emotional, and an unforgettable look into teenage life.", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 11 },
                    { 12, 112, "Hauntingly beautiful and thought-provoking.", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 12 },
                    { 13, 113, "A magical start to an epic series that captivates readers of all ages.", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 13 },
                    { 14, 114, "A chilling and prescient look at a dystopian future.", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 14 },
                    { 15, 115, "A beautifully written critique of the American Dream.", new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 15 },
                    { 16, 101, "While important, the pacing felt uneven, and some characters seemed underdeveloped.", new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 17, 102, "Overly descriptive passages bogged down the story's momentum.", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 18, 103, "Fascinating ideas, but the dense writing style made it difficult to stay engaged.", new DateTime(2023, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 },
                    { 19, 104, "The characters felt unrelatable and the ending was unsatisfying.", new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 },
                    { 20, 105, "While classic, the social satire feels outdated and struggles to resonate with modern audiences.", new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10 },
                    { 21, 114, "The philosophical themes often overshadowed the plot, leaving some parts dry and uninteresting.", new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 12 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BookClubId", "Content", "CreatedDate", "IsEdited", "IsPinned", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "I just finished 'To Kill a Mockingbird' and can't stop thinking about it! What did everyone else think about Atticus's approach to justice?", new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 1 },
                    { 2, 2, "Who else loved Bilbo's bravery in 'The Hobbit'? That scene with Smaug was incredible!", new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 2 },
                    { 3, 3, "'Dune' has such an intricate plot! Does anyone else find Paul Atreides's journey inspiring or overwhelming?", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 3 },
                    { 4, 4, "The twists in 'Gone Girl' left me reeling. How did you all interpret the ending?", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 4 },
                    { 5, 5, "Pride and Prejudice is so timeless. What are your favorite Darcy and Elizabeth moments?", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 5 },
                    { 6, 6, "The storytelling in 'The Book Thief' is so unique. What did you think of the perspective from Death?", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, 6 },
                    { 7, 7, "I'm still thinking about 'The Girl with the Dragon Tattoo.' Who else was blown away by the investigation twists?", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 7 },
                    { 8, 8, "The eerie atmosphere of 'The Haunting of Hill House' was so vivid! Who else couldn't sleep after reading it?", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, 8 },
                    { 9, 9, "I just finished '1984' and I’m still trying to process the dystopian world. How did you interpret Winston’s rebellion?", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 9 },
                    { 10, 10, "I can’t get over the plot twists in 'The Catcher in the Rye.' Did anyone else find Holden’s perspective on life relatable?", new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, 10 }
                });

            migrationBuilder.InsertData(
                table: "VotingSessions",
                columns: new[] { "Id", "BookClubId", "IsActive", "VotingEndDate", "VotingStartDate", "WinningBookId" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, 2, true, new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 3, false, new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107 },
                    { 4, 4, true, new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, 5, false, new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 113 },
                    { 6, 6, true, new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "I loved how Atticus stood up for what was right, even when it wasn’t popular. Truly inspiring.", new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, "Yeah, I agree! But I think the real hero was Scout, learning the world through her eyes was fascinating.", new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 3, "Bilbo was a true hero in this story, even though he didn’t see himself as one. The Smaug scene was amazing!", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 4, "I think Bilbo's journey is so relatable. It shows that you don’t have to be the strongest to do great things.", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 5, "I found Paul’s transformation overwhelming but fascinating. The world-building in 'Dune' is unreal!", new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 },
                    { 6, "The politics and the family dynamics are a lot to keep up with, but I’m loving the complexity!", new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 7, "The ending was shocking, but I feel like it was a bit too far-fetched. It didn’t sit well with me.", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8 },
                    { 8, "I loved how unpredictable it was. It made me rethink everything about the characters.", new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 9 },
                    { 9, "Darcy’s confession scene is my absolute favorite. The tension between them is perfect.", new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 10 },
                    { 10, "Elizabeth’s wit makes her so charming, but Darcy’s growth is what truly won me over.", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 11 },
                    { 11, "The perspective from Death was haunting, yet it gave the story a deeper emotional layer.", new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 12 },
                    { 12, "I agree! Death as a narrator was such a unique touch, and it added a lot of depth to the story.", new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 13 },
                    { 13, "The twists were mind-blowing. It kept me on the edge of my seat the entire time.", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 14 },
                    { 14, "I didn’t see the ending coming at all! It’s definitely one of those books you can’t stop thinking about.", new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 15 },
                    { 15, "I couldn’t put it down, but I was seriously creeped out. The atmosphere was perfect for a horror story.", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 16, "Hill House was so much more than just a haunted house. The psychological elements made it so unsettling.", new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_BookId",
                table: "BookClubs",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookClubs_HostId",
                table: "BookClubs",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_BookClubsHaveReadBook_HaveReadId",
                table: "BookClubsHaveReadBook",
                column: "HaveReadId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BookClubId",
                table: "Posts",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookClubMembership_MembersId",
                table: "UserBookClubMembership",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_BookId",
                table: "Vote",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_VotingSessionId",
                table: "Vote",
                column: "VotingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingSessionBooks_VotingSessionsId",
                table: "VotingSessionBooks",
                column: "VotingSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingSessions_BookClubId",
                table: "VotingSessions",
                column: "BookClubId");

            migrationBuilder.CreateIndex(
                name: "IX_VotingSessions_WinningBookId",
                table: "VotingSessions",
                column: "WinningBookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookClubsHaveReadBook");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserBookClubMembership");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "VotingSessionBooks");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "VotingSessions");

            migrationBuilder.DropTable(
                name: "BookClubs");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
