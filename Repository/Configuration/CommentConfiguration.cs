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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(comment => comment.User)
                .WithOne(user => user.)
                .HasForeignKey<Profile>(profile => profile.UserId);

            builder.HasData(
                new Comment()
                {
                    Id = new Guid("7245ed9b-2b7e-48f5-8ce4-50a11bdc2abf"),
                    UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                    CommentMessage = "제가 첫 번째 댓글이에요!",
                    CreatedDate = new DateTime(2023, 11, 02, 12, 11, 35)
                },
                new Comment()
                {
                    Id = new Guid("28d75fa9-35e8-41d4-b851-d6e604e187f8"),
                    UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                    CommentMessage = "안녕하세요 이순신님",
                    CreatedDate = new DateTime(2023, 11, 02, 12, 11, 35)
                }
            );
        }
    }
}
