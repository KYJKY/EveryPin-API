using Entites.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // 하나의 Post에는 여러 PostPhotos가 속할 수 있다
            builder.HasMany(post => post.PostPhotos)
                .WithOne(postPhoto => postPhoto.Post)
                .HasForeignKey(pp => pp.PostId);
            
            builder.HasMany(post => post.Likes)
                .WithOne(like => like.Post)
                .HasForeignKey(like => like.PostId);
            
            builder.HasMany(post => post.Comments)
                .WithOne(comment => comment.Post)
                .HasForeignKey(comment => comment.PostId);


            builder.HasData(
                // 홍길동 글
                new Post
                {
                    PostId = new Guid("9e6de066-282a-485c-8e2a-525f369d419f"),
                    UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                    PostContent = "홍길동 입니다 반갑습니다.",
                    PostPhotos = new List<PostPhoto> 
                    { 
                        new PostPhoto()
                        {
                            Id = new Guid("0a5aa5d8-9fb0-4b6f-82e9-7469b716fd26"),
                            PhotoUrl = "test"
                        }
                    },
                    Likes = new List<Like> 
                    {
                        new Like()
                        {
                            Id = new Guid("7245ed9b-2b7e-48f5-8ce4-50a11bdc2abf"),
                            UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                            CreatedDate = new DateTime(2023, 11, 02, 12, 10, 30),
                        }
                    },
                    Comments = new List<Comment> 
                    { 
                        new Comment()
                        {
                            Id = new Guid("7245ed9b-2b7e-48f5-8ce4-50a11bdc2abf"),
                            UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                            CommentMessage = "제가 첫 번째 댓글이에요!",
                            CreatedDate = new DateTime(2023, 11, 02, 12, 11, 35)
                        }
                    },
                    UpdateDate = null,
                    CreatedDate = new DateTime(2023, 11, 01, 12, 10, 30),
                },
                new Post
                {
                    PostId = new Guid("8d49546a-01b9-49f5-b504-b76aa834bb12"),
                    UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                    PostContent = "두 번째 글입니다.",
                    PostPhotos = null,
                    Likes = null,
                    Comments = null,
                    UpdateDate = null,
                    CreatedDate = new DateTime(2023, 11, 10, 12, 10, 30),
                },

                // 이순신 글
                new Post
                {
                    PostId = new Guid("b15bca7a-6bab-4ec6-8477-41314aee96ac"),
                    UserId = new Guid("f3d72088-6d16-4b5b-9689-11d1f93bb212"),
                    PostContent = "이순신 첫 글 입니다.",
                    PostPhotos = null,
                    Likes = new List<Like> 
                    {
                        new Like()
                        {
                            Id = new Guid("28d75fa9-35e8-41d4-b851-d6e604e187f8"),
                            UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                            CreatedDate = new DateTime(2023, 11, 12, 12, 10, 30),
                        }
                    },
                    Comments = new List<Comment> 
                    {
                        new Comment()
                        {
                            Id = new Guid("28d75fa9-35e8-41d4-b851-d6e604e187f8"),
                            UserId = new Guid("b85489c1-2b74-4db9-89f0-234f926f5ea0"),
                            CommentMessage = "안녕하세요 이순신님",
                            CreatedDate = new DateTime(2023, 11, 02, 12, 11, 35)
                        }
                    },
                    UpdateDate = new DateTime(2023, 11, 15, 14, 50, 12),
                    CreatedDate = new DateTime(2023, 11, 10, 14, 50, 12),
                }
            );
        }
    }
}
