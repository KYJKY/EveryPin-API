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
    internal sealed class LikeService : ILikeService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public LikeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<LikeDto> GetAllLike(bool trackChanges)
        {
            try
            {
                var likes = _repository.Like.GetAllLike(trackChanges);
                var likesDto = _mapper.Map<IEnumerable<LikeDto>>(likes);

                return likesDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
