using Contracts.Repository;
using Entites.Models;
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

        public IEnumerable<PostPhoto> GetAllPostPhoto(bool trackChanges)
        {
            try
            {
                var postPhotos = _repository.PostPhoto.GetAllPostPhoto(trackChanges);
                return postPhotos;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
