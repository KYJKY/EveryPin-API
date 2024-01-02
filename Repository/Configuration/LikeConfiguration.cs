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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasData(
                new Like()
                {
                    Id = new Guid("7245ed9b-2b7e-48f5-8ce4-50a11bdc2abf"),
                    UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                    CreatedDate = new DateTime(2023, 11, 02, 12, 10, 30),
                },
                new Like()
                {
                    Id = new Guid("28d75fa9-35e8-41d4-b851-d6e604e187f8"),
                    UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                    CreatedDate = new DateTime(2023, 11, 12, 12, 10, 30),
                }
            );
        }
    }
}
