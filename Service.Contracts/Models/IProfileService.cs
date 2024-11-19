﻿using Entites.Models;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models;

public interface IProfileService
{
    Task<IEnumerable<ProfileDto>> GetAllProfile(bool trackChanges);
    Task<Profile> CreateProfile(Profile profile);
    Task<Profile> GetProfileByUserId(string userId, bool trackChanges);
    void UpdateUserProfile(string userId, ProfileInputDto profileInputDto, bool trackChanges);
}
