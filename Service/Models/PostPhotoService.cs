using AutoMapper;
using Contracts.Repository;
using Entites.Models;
using Microsoft.Extensions.Logging;
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
        private readonly IMapper _mapper;

        public PostPhotoService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PostPhotoDto> GetAllPostPhoto(bool trackChanges)
        {
            var postPhotos = _repository.PostPhoto.GetAllPostPhoto(trackChanges);
            var postPhotosDto = _mapper.Map<IEnumerable<PostPhotoDto>>(postPhotos);

            return postPhotosDto;
        }
    }
}
