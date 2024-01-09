using Contracts.Repository;
using Shared.DataTransferObject;
using Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Service.Models
{
    internal sealed class CommentService : ICommentService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CommentService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            //_logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> GetAllComment(bool trackChanges)
        {
            try
            {
                var comments = _repository.Comment.GetAllComment(trackChanges);
                //var commentsDto = comments.Select(c => new CommentDto(c.Id, c.UserId, c.CommentMessage, c.CreatedDate)).ToList();
                var commentsDto = _mapper.Map<IEnumerable<CommentDto>>(comments);

                return commentsDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
