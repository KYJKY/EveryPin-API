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
    internal sealed class LikeService : ILikeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public LikeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<LikeDto> GetAllLike(bool trackChanges)
        {
            throw new Exception("테스트 오류");
            var likes = _repository.Like.GetAllLike(trackChanges);
            var likesDto = _mapper.Map<IEnumerable<LikeDto>>(likes);

            return likesDto;
        }
    }
}
