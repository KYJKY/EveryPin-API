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
    internal sealed class ProfileService : IProfileService
    {
        private readonly IRepositoryManager _repository;
        //private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProfileService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProfileDto> GetAllProfile(bool trackChanges)
        {
            try
            {
                var profiles = _repository.Profile.GetAllProfile(trackChanges);
                var profilesDto = _mapper.Map<IEnumerable<ProfileDto>>(profiles);

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
