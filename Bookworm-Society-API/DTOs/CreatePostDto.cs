﻿namespace Bookworm_Society_API.DTOs
{
    public class CreatePostDto
    {
        public string Content { get; set; }
        public int BookClubId { get; set; }
        public int UserId { get; set; }
    }
}
