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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasOne(user => user.Profile)
                .WithOne(profile => profile.User)
                .HasForeignKey<Profile>(profile => profile.UserId);

            builder.HasData(
                new User
                {
                    GoogleId = "test01",
                    GoogleName = "홍길동",
                    GoogleEmail = "test01@gmail.com",
                    KakaoId = null,
                    KakaoName = null,
                    KakaoEmail = null,
                },
                new User
                {
                    GoogleId = null,
                    GoogleName = null,
                    GoogleEmail = null,
                    KakaoId = "test02",
                    KakaoName = "이순신",
                    KakaoEmail = "test02@naver.com"
                }
            );
        }
    }
}
