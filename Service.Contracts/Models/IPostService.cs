using Entites.Models;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using Shared.DataTransferObject.OutputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models;

public interface IPostService
{
    Task<IEnumerable<PostDto>> GetAllPost(bool trackChanges);
    Task<PostPostPhotoDto> GetPost(int postId, bool trackChanges);
    Task<PostDto> CreatePost(CreatePostDto post);
    Task<IEnumerable<PostPostPhotoDto>> GetSearchPost(double x, double y, double range, bool trackChanges);
}
