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
    internal sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public PostService(IRepositoryManager repository, IMapper mapper)
        {
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
