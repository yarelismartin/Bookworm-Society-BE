using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class BookData
    {
        public static List<Book> Books = new()
{
            new() { Id = 101, Title = "To Kill a Mockingbird", Description = "A novel about the serious issues of rape and racial inequality.", Author = "Harper Lee", Genre = "Historical Fiction", imageUrl = "https://example.com/mock.jpg" },
            new() { Id = 102, Title = "The Hobbit", Description = "A journey through Middle-earth with Bilbo Baggins.", Author = "J.R.R. Tolkien", Genre = "Fantasy", imageUrl = "https://example.com/hobbit.jpg" },
            new() { Id = 103, Title = "Dune", Description = "A science fiction epic about politics, religion, and survival on the desert planet Arrakis.", Author = "Frank Herbert", Genre = "Science Fiction", imageUrl = "https://example.com/dune.jpg" },
            new() { Id = 104, Title = "Gone Girl", Description = "A psychological thriller about marriage and betrayal.", Author = "Gillian Flynn", Genre = "Mystery", imageUrl = "https://example.com/gonegirl.jpg" },
            new() { Id = 105, Title = "Pride and Prejudice", Description = "A romantic novel about the manners and matrimonial machinations of early 19th century England.", Author = "Jane Austen", Genre = "Romance", imageUrl = "https://example.com/pride.jpg" },
            new() { Id = 106, Title = "The Book Thief", Description = "The story of a young girl who steals books in Nazi Germany.", Author = "Markus Zusak", Genre = "Historical Fiction", imageUrl = "https://example.com/thief.jpg" },
            new() { Id = 107, Title = "The Girl with the Dragon Tattoo", Description = "A gripping thriller involving murder, mystery, and family secrets.", Author = "Stieg Larsson", Genre = "Thriller", imageUrl = "https://example.com/dragon.jpg" },
            new() { Id = 108, Title = "The Haunting of Hill House", Description = "A chilling tale of psychological horror and supernatural events.", Author = "Shirley Jackson", Genre = "Horror", imageUrl = "https://example.com/hillhouse.jpg" },
            new() { Id = 109, Title = "The Alchemist", Description = "A tale of self-discovery and pursuing one's dreams.", Author = "Paulo Coelho", Genre = "Slice of Life", imageUrl = "https://example.com/alchemist.jpg" },
            new() { Id = 110, Title = "Dracula", Description = "The classic vampire novel about the infamous Count Dracula.", Author = "Bram Stoker", Genre = "Horror", imageUrl = "https://example.com/dracula.jpg" },
            new() { Id = 111, Title = "The Catcher in the Rye", Description = "A story about teenage rebellion and angst.", Author = "J.D. Salinger", Genre = "Drama", imageUrl = "https://example.com/catcher.jpg" },
            new() { Id = 112, Title = "The Road", Description = "A post-apocalyptic novel about a father and son journeying through a devastated America.", Author = "Cormac McCarthy", Genre = "Adventure", imageUrl = "https://example.com/road.jpg" },
            new() { Id = 113, Title = "Harry Potter and the Sorcerer's Stone", Description = "The beginning of Harry Potter's journey in the wizarding world.", Author = "J.K. Rowling", Genre = "Fantasy", imageUrl = "https://example.com/harry.jpg" },
            new() { Id = 114, Title = "1984", Description = "A dystopian novel about totalitarianism and surveillance.", Author = "George Orwell", Genre = "Science Fiction", imageUrl = "https://example.com/1984.jpg" },
            new() { Id = 115, Title = "The Great Gatsby", Description = "A critique of the American Dream in the Jazz Age.", Author = "F. Scott Fitzgerald", Genre = "Drama", imageUrl = "https://example.com/gatsby.jpg" }
};

    }
}
