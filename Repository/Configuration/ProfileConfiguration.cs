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
            builder.HasData(
                new Profile
                {
                    Id = new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c"),
                    Name = "홍홍홍",
                    SelfIntroduction = "안녕하세요, 홍길동입니다.",
                    PhotoUrl = null,
                    UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                    UpdatedDate = null,
                    CreatedDate = DateTime.Now
                },
                new Profile
                {
                    Id = new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5"),
                    Name = "Yi Sun-sin",
                    SelfIntroduction = "명량해전의 이순신 입니다.",
                    PhotoUrl = null,
                    UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                    UpdatedDate = null,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
