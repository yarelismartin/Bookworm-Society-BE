using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookworm_Society_API.Migrations
{
    public partial class WorkingImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1534580235139-e2ef095e1972?q=80&w=1287&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1548445929-4f60a497f851?q=80&w=1170&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1701085496588-8f294c8cd063?q=80&w=1374&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1673635651187-8206328b0b61?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTN8fG15c3Rlcnl8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1459623837994-06d03aa27b9b?q=80&w=1332&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1726768903173-8cac387e97ab?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjF8fGhpc3RvcmljYWwlMjBib29rc3xlbnwwfHwwfHx8MA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1674521659179-b93d7eed75c8?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fHRocmlsbGVyfGVufDB8fDB8fHww");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1485855691614-f7547af0c4c5?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NDZ8fHN1cGVybmF0dXJhbHxlbnwwfHwwfHx8MA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1604960592081-96019492fcc4?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8dHJhdmVsJTIwYm9va3xlbnwwfHwwfHx8MA%3D%3D");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1595171694538-beb81da39d3e?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NTJ8fHRocmlsbGVyfGVufDB8fDB8fHww");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506863530036-1efeddceb993?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1689977807477-a579eda91fa2?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjF8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "ImageUrl", "LastName", "Uid" },
                values: new object[] { "Mike", "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", "Peluso", "efo48ObQwUVkUFx4ESFFuAcDz4q1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1675129522693-bd62ffe5e015?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1688740375397-34605b6abe48?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjl8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1690579805323-ce7193c0755d?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE0fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1693000697180-4e285198d71c?q=80&w=871&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1689531953275-a5cfcc458931?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE3fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1688739379441-fa764e016555?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDh8fHxlbnwwfHx8fHw%3D");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1689533448099-2dc408030f0f?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDI3fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1690579804905-86ee0f135a38?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE4fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1689568126014-06fea9d5d341?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDI4fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1690407617542-2f210cf20d7e?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDM0fHx8ZW58MHx8fHx8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://plus.unsplash.com/premium_photo-1689747698547-271d2d553cee?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDMyfHx8ZW58MHx8fHx8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/club1.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/club2.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/club3.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/club4.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/club5.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://example.com/club6.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://example.com/club7.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://example.com/club8.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://example.com/club9.jpg");

            migrationBuilder.UpdateData(
                table: "BookClubs",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://example.com/club10.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/alice.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/bob.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "ImageUrl", "LastName", "Uid" },
                values: new object[] { "Charlie", "https://example.com/charlie.jpg", "Brown", "UID24680" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/diana.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/edward.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://example.com/fiona.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://example.com/george.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://example.com/hannah.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://example.com/ian.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://example.com/jill.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://example.com/kyle.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://example.com/laura.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://example.com/mike.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://example.com/nina.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://example.com/oscar.jpg");
        }
    }
}
