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
            builder.HasData(
                new User
                {
                    GoogleId = "test01",
                    GoogleName = "홍길동",
                    GoogleEmail = "test01@gmail.com",
                    KakaoId = null,
                    KakaoName = null,
                    KakaoEmail = null,
                    ProfileId = new Guid("a13ffaa2-c689-4d24-8f65-12df4b9d724c")
                },
                new User
                {
                    GoogleId = null,
                    GoogleName = null,
                    GoogleEmail = null,
                    KakaoId = "test02",
                    KakaoName = "이순신",
                    KakaoEmail = "test02@naver.com",
                    ProfileId = new Guid("8b23a1d6-860a-4ff2-becd-d7c8a8c238a5")
                }
            );
        }
    }
}
