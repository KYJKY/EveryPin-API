using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasOne(profile => profile.UserId)
                .WithOne(comment => comment.Post)
                .HasForeignKey(comment => comment.PostId);

            builder.HasData(
                new Profile
                {
                    Id = new Guid(),
                    Name = "홍홍홍",
                    SelfIntroduction = "안녕하세요, 홍길동입니다.",
                    PhotoUrl = null,
                    UpdatedDate = null,
                    CreatedDate = DateTime.Now
                },
                new Profile
                {
                    Id = new Guid(),
                    Name = "Yi Sun-sin",
                    SelfIntroduction = "명량해전의 이순신 입니다.",
                    PhotoUrl = null,
                    UpdatedDate = null,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
