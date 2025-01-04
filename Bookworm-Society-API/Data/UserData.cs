using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class UserData
    {
        public static List<User> Users = new()
{
        new() { Id = 1, FirstName = "Alice", LastName = "Johnson", ImageUrl = "https://images.unsplash.com/photo-1506863530036-1efeddceb993?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "alicej", JoinedDate = new DateTime(2023, 8, 15), Uid = "UID12345" },
        new() { Id = 2, FirstName = "Bob", LastName = "Smith", ImageUrl = "https://plus.unsplash.com/premium_photo-1689977807477-a579eda91fa2?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjF8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "bobsmith", JoinedDate = new DateTime(2023, 7, 20), Uid = "UID67890" },
        new() { Id = 3, FirstName = "Mike", LastName = "Peluso", ImageUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjB8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "charlieb", JoinedDate = new DateTime(2023, 6, 10), Uid = "efo48ObQwUVkUFx4ESFFuAcDz4q1" },
        new() { Id = 4, FirstName = "Diana", LastName = "Prince", ImageUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTZ8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "dianap", JoinedDate = new DateTime(2023, 5, 25), Uid = "UID13579" },
        new() { Id = 5, FirstName = "Edward", LastName = "Elric", ImageUrl = "https://plus.unsplash.com/premium_photo-1675129522693-bd62ffe5e015?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "edwarde", JoinedDate = new DateTime(2023, 4, 12), Uid = "UID11223" },
        new() { Id = 6, FirstName = "Fiona", LastName = "Hill", ImageUrl = "https://plus.unsplash.com/premium_photo-1688740375397-34605b6abe48?w=1000&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mjl8fHByb2ZpbGV8ZW58MHx8MHx8fDA%3D", Username = "fionah", JoinedDate = new DateTime(2023, 3, 8), Uid = "UID44556" },
        new() { Id = 7, FirstName = "George", LastName = "Harrison", ImageUrl = "https://plus.unsplash.com/premium_photo-1690579805323-ce7193c0755d?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE0fHx8ZW58MHx8fHx8", Username = "georgeh", JoinedDate = new DateTime(2023, 2, 18), Uid = "UID77889" },
        new() { Id = 8, FirstName = "Hannah", LastName = "Montana", ImageUrl = "https://plus.unsplash.com/premium_photo-1693000697180-4e285198d71c?q=80&w=871&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", Username = "hannahm", JoinedDate = new DateTime(2023, 1, 15), Uid = "UID99101" },
        new() { Id = 9, FirstName = "Ian", LastName = "Curtis", ImageUrl = "https://plus.unsplash.com/premium_photo-1689531953275-a5cfcc458931?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE3fHx8ZW58MHx8fHx8", Username = "ianc", JoinedDate = new DateTime(2022, 12, 1), Uid = "UID22334" },
        new() { Id = 10, FirstName = "Jill", LastName = "Valentine", ImageUrl = "https://plus.unsplash.com/premium_photo-1688739379441-fa764e016555?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDh8fHxlbnwwfHx8fHw%3D", Username = "jillv", JoinedDate = new DateTime(2022, 11, 5), Uid = "UID55667" },
        new() { Id = 11, FirstName = "Kyle", LastName = "Reese", ImageUrl = "https://plus.unsplash.com/premium_photo-1689533448099-2dc408030f0f?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDI3fHx8ZW58MHx8fHx8", Username = "kyler", JoinedDate = new DateTime(2022, 10, 20), Uid = "UID77880" },
        new() { Id = 12, FirstName = "Laura", LastName = "Croft", ImageUrl = "https://plus.unsplash.com/premium_photo-1690579804905-86ee0f135a38?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE4fHx8ZW58MHx8fHx8", Username = "laurac", JoinedDate = new DateTime(2022, 9, 10), Uid = "UID99112" },
        new() { Id = 13, FirstName = "Mike", LastName = "Tyson", ImageUrl = "https://plus.unsplash.com/premium_photo-1689568126014-06fea9d5d341?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDI4fHx8ZW58MHx8fHx8", Username = "miket", JoinedDate = new DateTime(2022, 8, 15), Uid = "UID22344" },
        new() { Id = 14, FirstName = "Nina", LastName = "Williams", ImageUrl = "https://plus.unsplash.com/premium_photo-1690407617542-2f210cf20d7e?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDM0fHx8ZW58MHx8fHx8", Username = "ninaw", JoinedDate = new DateTime(2022, 7, 25), Uid = "UID55678" },
        new() { Id = 15, FirstName = "Oscar", LastName = "Wilde", ImageUrl = "https://plus.unsplash.com/premium_photo-1689747698547-271d2d553cee?w=400&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDMyfHx8ZW58MHx8fHx8", Username = "oscarw", JoinedDate = new DateTime(2022, 6, 30), Uid = "UID77891" }
};

    }
}
