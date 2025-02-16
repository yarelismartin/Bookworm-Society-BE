using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class BookData
    {
        public static List<Book> Books = new()
{
           new() { Id = 101, Title = "To Kill a Mockingbird", Description = "A novel about the serious issues of rape and racial inequality.", AuthorId = 1, Genre = "Historical Fiction", ImageUrl = "https://m.media-amazon.com/images/I/81aY1lxk+9L._SL1500_.jpg" },
            new() { Id = 102, Title = "The Hobbit", Description = "A journey through Middle-earth with Bilbo Baggins.", AuthorId = 2, Genre = "Fantasy", ImageUrl = "https://m.media-amazon.com/images/I/71mK6W2wMrL._SL1500_.jpg" },
            new() { Id = 103, Title = "Dune", Description = "A science fiction epic about politics, religion, and survival on the desert planet Arrakis.", AuthorId = 3, Genre = "Science Fiction", ImageUrl = "https://m.media-amazon.com/images/I/71+IVP4wnEL._SL1500_.jpg" },
            new() { Id = 104, Title = "Gone Girl", Description = "A psychological thriller about marriage and betrayal.", AuthorId = 4, Genre = "Mystery", ImageUrl = "https://m.media-amazon.com/images/I/61mcHA1yJLL._SL1141_.jpg" },
            new() { Id = 105, Title = "Pride and Prejudice", Description = "A romantic novel about the manners and matrimonial machinations of early 19th century England.", AuthorId = 5, Genre = "Romance", ImageUrl = "https://m.media-amazon.com/images/I/51zkOaWMu7S._SL1500_.jpg" },
            new() { Id = 106, Title = "The Book Thief", Description = "The story of a young girl who steals books in Nazi Germany.", AuthorId = 6, Genre = "Historical Fiction", ImageUrl = "https://m.media-amazon.com/images/I/914cHl9v7oL._SL1500_.jpg" },
            new() { Id = 107, Title = "The Girl with the Dragon Tattoo", Description = "A gripping thriller involving murder, mystery, and family secrets.", AuthorId = 7, Genre = "Thriller", ImageUrl = "https://m.media-amazon.com/images/I/51rKlSld33L.jpg" },
            new() { Id = 108, Title = "The Haunting of Hill House", Description = "A chilling tale of psychological horror and supernatural events.", AuthorId = 8, Genre = "Horror", ImageUrl = "https://m.media-amazon.com/images/I/81HAeHFZ9oL._SL1500_.jpg" },
            new() { Id = 109, Title = "The Alchemist", Description = "A tale of self-discovery and pursuing one's dreams.", AuthorId = 9, Genre = "Slice of Life", ImageUrl = "https://m.media-amazon.com/images/I/71zHDXu1TaL._SL1500_.jpg" },
            new() { Id = 110, Title = "Dracula", Description = "The classic vampire novel about the infamous Count Dracula.", AuthorId = 10, Genre = "Horror", ImageUrl = "https://m.media-amazon.com/images/I/71dGP-WQ0HL._SL1499_.jpg" },
            new() { Id = 111, Title = "The Catcher in the Rye", Description = "A story about teenage rebellion and angst.", AuthorId = 11, Genre = "Drama", ImageUrl = "https://m.media-amazon.com/images/I/71nXPGovoTL._SL1500_.jpg" },
            new() { Id = 112, Title = "The Road", Description = "A post-apocalyptic novel about a father and son journeying through a devastated America.", AuthorId = 12, Genre = "Adventure", ImageUrl = "https://m.media-amazon.com/images/I/51M7XGLQTBL._SL1200_.jpg" },
            new() { Id = 113, Title = "Harry Potter and the Sorcerer's Stone", Description = "The beginning of Harry Potter's journey in the wizarding world.", AuthorId = 13, Genre = "Fantasy", ImageUrl = "https://m.media-amazon.com/images/I/91A6EgLH+2L._SL1500_.jpg" },
            new() { Id = 114, Title = "1984", Description = "A dystopian novel about totalitarianism and surveillance.", AuthorId = 14, Genre = "Science Fiction", ImageUrl = "https://m.media-amazon.com/images/I/51A9t9irmEL._SY445_SX342_.jpg" },
            new() { Id = 115, Title = "The Great Gatsby", Description = "A critique of the American Dream in the Jazz Age.", AuthorId = 15, Genre = "Drama", ImageUrl = "https://m.media-amazon.com/images/I/61PxxqzdJPL._SL1491_.jpg" }
};

    }
}
