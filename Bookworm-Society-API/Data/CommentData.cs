using Bookworm_Society_API.Models;

namespace Bookworm_Society_API.Data
{
    public class CommentData
    {
        public static List<Comment> Comments = new()
        {
            // Comments for Post 1: "I just finished 'To Kill a Mockingbird'..."
            new() { Id = 1, Content = "I loved how Atticus stood up for what was right, even when it wasn’t popular. Truly inspiring.", CreatedDate = new DateTime(2023, 11, 2), PostId = 1, UserId = 2 },
            new() { Id = 2, Content = "Yeah, I agree! But I think the real hero was Scout, learning the world through her eyes was fascinating.", CreatedDate = new DateTime(2023, 11, 3), PostId = 1, UserId = 3 },
    
            // Comments for Post 2: "Who else loved Bilbo's bravery in 'The Hobbit'?"
            new() { Id = 3, Content = "Bilbo was a true hero in this story, even though he didn’t see himself as one. The Smaug scene was amazing!", CreatedDate = new DateTime(2023, 10, 26), PostId = 2, UserId = 4 },
            new() { Id = 4, Content = "I think Bilbo's journey is so relatable. It shows that you don’t have to be the strongest to do great things.", CreatedDate = new DateTime(2023, 10, 27), PostId = 2, UserId = 5 },
    
            // Comments for Post 3: "'Dune' has such an intricate plot! Does anyone else find Paul Atreides's journey inspiring or overwhelming?"
            new() { Id = 5, Content = "I found Paul’s transformation overwhelming but fascinating. The world-building in 'Dune' is unreal!", CreatedDate = new DateTime(2023, 9, 16), PostId = 3, UserId = 6 },
            new() { Id = 6, Content = "The politics and the family dynamics are a lot to keep up with, but I’m loving the complexity!", CreatedDate = new DateTime(2023, 9, 17), PostId = 3, UserId = 7 },
    
            // Comments for Post 4: "The twists in 'Gone Girl' left me reeling. How did you all interpret the ending?"
            new() { Id = 7, Content = "The ending was shocking, but I feel like it was a bit too far-fetched. It didn’t sit well with me.", CreatedDate = new DateTime(2023, 9, 1), PostId = 4, UserId = 8 },
            new() { Id = 8, Content = "I loved how unpredictable it was. It made me rethink everything about the characters.", CreatedDate = new DateTime(2023, 9, 2), PostId = 4, UserId = 9 },
    
            // Comments for Post 5: "Pride and Prejudice is so timeless. What are your favorite Darcy and Elizabeth moments?"
            new() { Id = 9, Content = "Darcy’s confession scene is my absolute favorite. The tension between them is perfect.", CreatedDate = new DateTime(2023, 7, 21), PostId = 5, UserId = 10 },
            new() { Id = 10, Content = "Elizabeth’s wit makes her so charming, but Darcy’s growth is what truly won me over.", CreatedDate = new DateTime(2023, 7, 22), PostId = 5, UserId = 11 },
    
            // Comments for Post 6: "The storytelling in 'The Book Thief' is so unique. What did you think of the perspective from Death?"
            new() { Id = 11, Content = "The perspective from Death was haunting, yet it gave the story a deeper emotional layer.", CreatedDate = new DateTime(2023, 6, 16), PostId = 6, UserId = 12 },
            new() { Id = 12, Content = "I agree! Death as a narrator was such a unique touch, and it added a lot of depth to the story.", CreatedDate = new DateTime(2023, 6, 17), PostId = 6, UserId = 13 },

            // Comments for Post 7: "I'm still thinking about 'The Girl with the Dragon Tattoo.' Who else was blown away by the investigation twists?"
            new() { Id = 13, Content = "The twists were mind-blowing. It kept me on the edge of my seat the entire time.", CreatedDate = new DateTime(2023, 5, 12), PostId = 7, UserId = 14 },
            new() { Id = 14, Content = "I didn’t see the ending coming at all! It’s definitely one of those books you can’t stop thinking about.", CreatedDate = new DateTime(2023, 5, 13), PostId = 7, UserId = 15 },

            // Comments for Post 8: "The eerie atmosphere of 'The Haunting of Hill House' was so vivid! Who else couldn't sleep after reading it?"
            new() { Id = 15, Content = "I couldn’t put it down, but I was seriously creeped out. The atmosphere was perfect for a horror story.", CreatedDate = new DateTime(2023, 4, 22), PostId = 8, UserId = 1 },
            new() { Id = 16, Content = "Hill House was so much more than just a haunted house. The psychological elements made it so unsettling.", CreatedDate = new DateTime(2023, 4, 23), PostId = 8, UserId = 2 }
        };

    }
}
