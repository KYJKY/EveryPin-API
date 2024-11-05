using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models;

public interface IPostPhotoService
{
    Task<IEnumerable<PostPhotoDto>> GetAllPostPhoto(bool trackChanges);
    Task<IEnumerable<PostPhotoDto>> GetPostPhotoToPostId(int postId, bool trackChanges);
    Task<PostPhotoDto> CreatePostPhoto(CreatePostPhotoDto postphoto);
}
