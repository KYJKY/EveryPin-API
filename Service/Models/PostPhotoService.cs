using AutoMapper;
using Contracts.Repository;
using Entites.Exceptions;
using Entites.Models;
using Microsoft.Extensions.Logging;
using Service.Models;
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
        private readonly ILogger<PostPhotoService> _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostPhotoService(ILogger<PostPhotoService> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PostPhotoDto> GetAllPostPhoto(bool trackChanges)
        {
            var postPhotos = _repository.PostPhoto.GetAllPostPhoto(trackChanges);
            var postPhotosDto = _mapper.Map<IEnumerable<PostPhotoDto>>(postPhotos);

            return postPhotosDto;
        }

        public IEnumerable<PostPhotoDto> GetPostPhotoToPostId(int postId, bool trackChanges)
        {
            var post = _repository.Post.GetPost(postId, trackChanges);

            if (post is null)
                throw new PostNotFoundException(postId);

            var postPhotosFromDb = _repository.PostPhoto.GetPostPhotoToPostId(postId, trackChanges);
            var postPhotosDto = _mapper.Map<IEnumerable<PostPhotoDto>>(postPhotosFromDb);

            return postPhotosDto;
        }
    }
}
