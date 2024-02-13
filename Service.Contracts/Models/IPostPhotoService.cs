using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface IPostPhotoService
    {
        IEnumerable<PostPhotoDto> GetAllPostPhoto(bool trackChanges);
        IEnumerable<PostPhotoDto> GetPostPhotoToPostId(int postId, bool trackChanges);
        PostPhotoDto CreatePostPhoto(CreatePostPhotoDto postphoto);
    }
}
