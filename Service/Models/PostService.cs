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
    internal sealed class PostService : IPostService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PostService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PostDto> GetAllPost(bool trackChanges)
        {
            try
            {
                var posts = _repository.Post.GetAllPost(trackChanges);
                var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

                return postsDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
