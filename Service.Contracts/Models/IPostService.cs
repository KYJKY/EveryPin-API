using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPost(bool trackChanges);
        Task<PostDto> GetPost(int postId, bool trackChanges);
        Task<PostDto> CreatePost(CreatePostDto post);
        Task<IEnumerable<PostDto>> GetSearchPost(double x, double y, double range, bool trackChanges);
    }
}
