using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
       
        public BookDTO(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            ImageUrl = book.ImageUrl;
        }
    }
}
