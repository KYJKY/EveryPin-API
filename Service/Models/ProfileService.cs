using AutoMapper;
using Contracts.Repository;
using Entites.Models;
using Microsoft.Extensions.Logging;
using Service.Models;
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
        private readonly ILogger<ProfileService> _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProfileService(ILogger<ProfileService> logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProfileDto> GetAllProfile(bool trackChanges)
        {
            var profiles = _repository.Profile.GetAllProfile(trackChanges);
            var profilesDto = _mapper.Map<IEnumerable<ProfileDto>>(profiles);

            return profilesDto;
        }
    }
}
