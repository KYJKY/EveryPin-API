using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration;

public class CodeOAuthPlatformConfiguration : IEntityTypeConfiguration<CodeOAuthPlatform>
{
    public void Configure(EntityTypeBuilder<CodeOAuthPlatform> builder)
    {
        builder.HasData(
            new CodeOAuthPlatform
            {
                Id = -1,
                PlatformName = "NONE"
            },
            new CodeOAuthPlatform
            {
                Id = 1,
                PlatformName = "KAKAO"
            },
            new CodeOAuthPlatform
            {
                Id = 2,
                PlatformName = "GOOGLE"
            }
        );
    }
}
