﻿using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository.Models
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPost(bool trackChanges);
        Task<Post> GetPostById(int postId, bool trackChanges);
        void CreatePost(Post post);
    }
}
