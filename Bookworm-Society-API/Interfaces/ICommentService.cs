﻿using Bookworm_Society_API.DTOs;
using Bookworm_Society_API.Models;
using Bookworm_Society_API.Result;

namespace Bookworm_Society_API.Interfaces
{
    public interface ICommentService
    {
        Task<Result<Comment>> CreateCommentAsync(CreateCommentDTO commentDTO);
        Task<Result<Comment>> DeleteCommentAsync(int commentId);
    }
}
