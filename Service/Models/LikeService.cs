using Contracts.Repository;
using Entites.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    internal sealed class LikeService : ILikeService
    {
        private readonly IRepositoryManager _repository;

        public LikeService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<LikeDto> GetAllLike(bool trackChanges)
        {
            try
            {
                var likes = _repository.Like.GetAllLike(trackChanges);
                var likesDto = likes.Select(c => new LikeDto(c.Id, c.UserId, c.CreatedDate)).ToList();

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
