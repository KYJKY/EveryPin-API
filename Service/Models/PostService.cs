using AutoMapper;
using Contracts.Repository;
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
    internal sealed class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostService(ILogger<PostService> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PostDto> GetAllPost(bool trackChanges)
        {
            var posts = _repository.Post.GetAllPost(trackChanges);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postsDto;
        }
    }
}
