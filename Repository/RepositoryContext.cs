using Entites.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // 더미 데이터 생성
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new CodeOAuthPlatformConfiguration());

        //// 선택적 1:1
        //modelBuilder.Entity<User>()
        //            .HasOne(user => user.Profile)
        //            .WithOne(profile => profile.User)
        //            .HasForeignKey<Profile>(profile => profile.UserId)
        //            .IsRequired(false);
        //
        //// 일대다
        //modelBuilder.Entity<Post>()
        //            .HasMany(post => post.Comments)
        //            .WithOne(comment => comment.Post)
        //            .HasForeignKey(comment => comment.PostId);
        //modelBuilder.Entity<Post>()
        //            .HasMany(post => post.Likes)
        //            .WithOne(comment => comment.Post)
        //            .HasForeignKey(comment => comment.PostId);
        //modelBuilder.Entity<Post>()
        //            .HasMany(post => post.PostPhotos)
        //            .WithOne(comment => comment.Post)
        //            .HasForeignKey(comment => comment.PostId);
        //
        //// 1:1
        //modelBuilder.Entity<Like>()
        //            .HasOne(like => like.User)
        //            .WithOne(user => user.)
        //            .HasForeignKey<Profile>(profile => profile.UserId);
        //
    }

    public DbSet<Profile>? Profiles { get; set; }
    public DbSet<Post>? Posts { get; set; }
    public DbSet<PostPhoto>? PostPhotos { get; set; }
    public DbSet<Like>? Likes { get; set; }
    public DbSet<Comment>? Comments { get; set; }
}