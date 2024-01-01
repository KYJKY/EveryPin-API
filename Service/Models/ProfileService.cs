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
    internal sealed class ProfileService : IProfileService
    {
        private readonly IRepositoryManager _repository;

        public ProfileService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProfileDto> GetAllProfile(bool trackChanges)
        {
            try
            {
                var profiles = _repository.Profile.GetAllProfile(trackChanges);
                var profilesDto = profiles.Select(p => new ProfileDto(p.Id, p.Name, p.SelfIntroduction, p.PhotoUrl, p.UserId, p.UpdatedDate, p.CreatedDate));
                
                return profilesDto;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
