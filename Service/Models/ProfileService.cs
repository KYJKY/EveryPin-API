using Contracts.Repository;
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
    }
}
