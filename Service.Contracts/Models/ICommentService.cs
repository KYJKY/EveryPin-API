﻿using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models;

public interface ICommentService
{
    Task<IEnumerable<CommentDto>> GetAllComment(bool trackChanges);
    Task<IEnumerable<CommentDto>> GetCommentToPostId(int postId, bool trackChanges);
    Task<CommentDto> CreateComment(CreateCommentDto comment);
}
