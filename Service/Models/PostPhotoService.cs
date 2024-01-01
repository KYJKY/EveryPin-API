using Contracts.Repository;
using Entites.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    internal sealed class PostPhotoService : IPostPhotoService
    {
        private readonly IRepositoryManager _repository;

        public PostPhotoService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<PostPhotoDto> GetAllPostPhoto(bool trackChanges)
        {
            try
            {
                var postPhotos = _repository.PostPhoto.GetAllPostPhoto(trackChanges);
                var postPhotosDto = postPhotos.Select(p => new PostPhotoDto(p.Id, p.photoUrl)).ToList();
                
                return postPhotosDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
