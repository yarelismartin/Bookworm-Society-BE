using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class PostData
    {
        public static List<Post> Posts = new()
        {
            new() { Id = 1, Content = "I just finished 'To Kill a Mockingbird' and can't stop thinking about it! What did everyone else think about Atticus's approach to justice?", CreatedDate = new DateTime(2023, 11, 1), isPinned = false, isEdited = false, BookClubId = 1, UserId = 1 },
            new() { Id = 2, Content = "Who else loved Bilbo's bravery in 'The Hobbit'? That scene with Smaug was incredible!", CreatedDate = new DateTime(2023, 10, 25), isPinned = false, isEdited = true, BookClubId = 2, UserId = 2 },
            new() { Id = 3, Content = "'Dune' has such an intricate plot! Does anyone else find Paul Atreides's journey inspiring or overwhelming?", CreatedDate = new DateTime(2023, 9, 15), isPinned = true, isEdited = false, BookClubId = 3, UserId = 3 },
            new() { Id = 4, Content = "The twists in 'Gone Girl' left me reeling. How did you all interpret the ending?", CreatedDate = new DateTime(2023, 8, 30), isPinned = false, isEdited = false, BookClubId = 4, UserId = 4 },
            new() { Id = 5, Content = "Pride and Prejudice is so timeless. What are your favorite Darcy and Elizabeth moments?", CreatedDate = new DateTime(2023, 7, 20), isPinned = false, isEdited = true, BookClubId = 5, UserId = 5 },
            new() { Id = 6, Content = "The storytelling in 'The Book Thief' is so unique. What did you think of the perspective from Death?", CreatedDate = new DateTime(2023, 6, 15), isPinned = true, isEdited = false, BookClubId = 6, UserId = 6 },
            new() { Id = 7, Content = "I'm still thinking about 'The Girl with the Dragon Tattoo.' Who else was blown away by the investigation twists?", CreatedDate = new DateTime(2023, 5, 10), isPinned = false, isEdited = false, BookClubId = 7, UserId = 7 },
            new() { Id = 8, Content = "The eerie atmosphere of 'The Haunting of Hill House' was so vivid! Who else couldn't sleep after reading it?", CreatedDate = new DateTime(2023, 4, 5), isPinned = false, isEdited = true, BookClubId = 8, UserId = 8 },
            new() { Id = 9, Content = "I just finished '1984' and I’m still trying to process the dystopian world. How did you interpret Winston’s rebellion?", CreatedDate = new DateTime(2023, 11, 10), isPinned = false, isEdited = false, BookClubId = 9, UserId = 9 },
            new() { Id = 10, Content = "I can’t get over the plot twists in 'The Catcher in the Rye.' Did anyone else find Holden’s perspective on life relatable?", CreatedDate = new DateTime(2023, 10, 18), isPinned = false, isEdited = false, BookClubId = 10, UserId = 10 },
            new() { Id = 11, Content = "Reading 'Frankenstein' again, and it's amazing how relevant it still is! How do you think the monster represents society’s treatment of the other?", CreatedDate = new DateTime(2023, 9, 10), isPinned = false, isEdited = true, BookClubId = 11, UserId = 11 },
            new() { Id = 12, Content = "Anyone else read 'The Outsiders' recently? I still think Ponyboy’s experiences resonate today, especially with youth and class struggles.", CreatedDate = new DateTime(2023, 8, 30), isPinned = false, isEdited = false, BookClubId = 12, UserId = 12 },
            new() { Id = 13, Content = "Just started 'The Night Circus.' The magical realism is so captivating! Can’t wait to see where this goes. Anyone else reading it?", CreatedDate = new DateTime(2023, 7, 25), isPinned = false, isEdited = false, BookClubId = 13, UserId = 13 },
            new() { Id = 14, Content = "Was anyone else confused by 'Moby-Dick?' The symbolism is so layered, but some parts just dragged. What did you think of Ishmael’s role?", CreatedDate = new DateTime(2023, 6, 10), isPinned = false, isEdited = false, BookClubId = 14, UserId = 14 },
            new() { Id = 15, Content = "Just finished 'The Great Gatsby.' It’s tragic how much Gatsby’s dream costs him. What do you think the novel says about the American Dream?", CreatedDate = new DateTime(2023, 5, 15), isPinned = false, isEdited = true, BookClubId = 15, UserId = 15 },
            new() { Id = 16, Content = "I loved 'The Hunger Games,' but the ending felt rushed. Who else felt like Katniss's journey was left incomplete?", CreatedDate = new DateTime(2023, 4, 20), isPinned = false, isEdited = false, BookClubId = 16, UserId = 1 }
        };
    }
}
