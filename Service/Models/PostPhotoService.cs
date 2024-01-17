using AutoMapper;
using Contracts.Repository;
using Entites.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Contracts.Models
{
    internal sealed class PostPhotoService : IPostPhotoService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PostPhotoService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PostPhotoDto> GetAllPostPhoto(bool trackChanges)
        {
            try
            {
                var postPhotos = _repository.PostPhoto.GetAllPostPhoto(trackChanges);
                var postPhotosDto = _mapper.Map<IEnumerable<PostPhotoDto>>(postPhotos);

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
