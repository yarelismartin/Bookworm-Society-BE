using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class PostData
    {
        public static List<Post> Posts = new()
        {
            new() { Id = 1, Content = "I just finished 'To Kill a Mockingbird' and can't stop thinking about it! What did everyone else think about Atticus's approach to justice?", CreatedDate = new DateTime(2023, 11, 1), IsPinned = false, IsEdited = false, BookClubId = 1, UserId = 1 },
            new() { Id = 2, Content = "Who else loved Bilbo's bravery in 'The Hobbit'? That scene with Smaug was incredible!", CreatedDate = new DateTime(2023, 10, 25), IsPinned = false, IsEdited = true, BookClubId = 2, UserId = 2 },
            new() { Id = 3, Content = "'Dune' has such an intricate plot! Does anyone else find Paul Atreides's journey inspiring or overwhelming?", CreatedDate = new DateTime(2023, 9, 15), IsPinned = true, IsEdited = false, BookClubId = 3, UserId = 3 },
            new() { Id = 4, Content = "The twists in 'Gone Girl' left me reeling. How did you all interpret the ending?", CreatedDate = new DateTime(2023, 8, 30), IsPinned = false, IsEdited = false, BookClubId = 4, UserId = 4 },
            new() { Id = 5, Content = "Pride and Prejudice is so timeless. What are your favorite Darcy and Elizabeth moments?", CreatedDate = new DateTime(2023, 7, 20), IsPinned = false, IsEdited = true, BookClubId = 5, UserId = 5 },
            new() { Id = 6, Content = "The storytelling in 'The Book Thief' is so unique. What did you think of the perspective from Death?", CreatedDate = new DateTime(2023, 6, 15), IsPinned = true, IsEdited = false, BookClubId = 6, UserId = 6 },
            new() { Id = 7, Content = "I'm still thinking about 'The Girl with the Dragon Tattoo.' Who else was blown away by the investigation twists?", CreatedDate = new DateTime(2023, 5, 10), IsPinned = false, IsEdited = false, BookClubId = 7, UserId = 7 },
            new() { Id = 8, Content = "The eerie atmosphere of 'The Haunting of Hill House' was so vivid! Who else couldn't sleep after reading it?", CreatedDate = new DateTime(2023, 4, 5), IsPinned = false, IsEdited = true, BookClubId = 8, UserId = 8 },
            new() { Id = 9, Content = "I just finished '1984' and I’m still trying to process the dystopian world. How did you interpret Winston’s rebellion?", CreatedDate = new DateTime(2023, 11, 10), IsPinned = false, IsEdited = false, BookClubId = 9, UserId = 9 },
            new() { Id = 10, Content = "I can’t get over the plot twists in 'The Catcher in the Rye.' Did anyone else find Holden’s perspective on life relatable?", CreatedDate = new DateTime(2023, 10, 18), IsPinned = false, IsEdited = false, BookClubId = 10, UserId = 10 },
            
        };
    }
}
