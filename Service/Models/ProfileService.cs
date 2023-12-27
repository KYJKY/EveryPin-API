using Contracts.Repository;
using Entites.Models;
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

        public IEnumerable<Profile> GetAllProfile(bool trackChanges)
        {
            try
            {
                var profiles = _repository.Profile.GetAllProfile(trackChanges);
                return profiles;
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong in the { nameof(GetAllCompanies) } service method { ex }");

                throw;
            }
        }
    }
}
