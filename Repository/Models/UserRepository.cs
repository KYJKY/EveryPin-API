using Contracts.Repository.Models;
using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<User>> GetAllUser(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(c => c.Id)
        .ToListAsync();

    public async Task<User> GetUserByEmail(string email, bool tackChanges) =>
        await FindByCondition(u => u.Email.Equals(email), tackChanges)
        .SingleOrDefaultAsync();
}
