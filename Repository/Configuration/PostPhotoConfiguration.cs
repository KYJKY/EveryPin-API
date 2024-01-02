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
    public class PostPhotoConfiguration : IEntityTypeConfiguration<PostPhoto>
    {
        public void Configure(EntityTypeBuilder<PostPhoto> builder)
        {
            builder.HasData(
                new PostPhoto()
                {
                    Id = new Guid("0a5aa5d8-9fb0-4b6f-82e9-7469b716fd26"),
                    PhotoUrl = "test"
                }
            );
        }
    }
}
