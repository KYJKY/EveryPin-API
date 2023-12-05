using Entites.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Profile>? Profiles { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<PostPhoto>? PostPhotos { get; set; }
        public DbSet<Like>? Likes { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}