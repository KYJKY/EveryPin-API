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
using Entites.Exceptions;
using System.ComponentModel.Design;

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

        public IEnumerable<CommentDto> GetCommentToPostId(int postId, bool trackChanges)
        {
            var post = _repository.Post.GetPost(postId, trackChanges);

            if (post is null)
                throw new PostNotFoundException(postId);

            var commentsFromDb = _repository.Comment.GetCommentToPostId(postId, trackChanges);
            var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(commentsFromDb);

            return commentsDto;
        }

        public CommentDto CreateComment(CreateCommentDto comment)
        {
            var commentEntity = _mapper.Map<Comment>(comment);

            _repository.Comment.CreateComment(commentEntity);
            _repository.Save();

            var commentToReturn = _mapper.Map<CommentDto>(commentEntity);

            return commentToReturn;
        }
    }
}
