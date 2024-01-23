using Contracts.Repository;
using Shared.DataTransferObject;
using Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entites.Models;
using Microsoft.Extensions.Logging;

namespace Service.Models
{
    internal sealed class CommentService : ICommentService
    {
        private readonly ILogger _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CommentService(ILogger<CommentService> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> GetAllComment(bool trackChanges)
        {
            var comments = _repository.Comment.GetAllComment(trackChanges);
            //var commentsDto = comments.Select(c => new CommentDto(c.Id, c.UserId, c.CommentMessage, c.CreatedDate)).ToList();
            var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);

            return commentsDto;
        }
    }
}
