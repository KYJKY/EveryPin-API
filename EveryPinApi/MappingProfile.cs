using AutoMapper;
using Entites.Models;
using Shared.DataTransferObject;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EveryPinApi
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<CreatePostDto, Post>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CreateCommentDto, Comment>();
            
            CreateMap<Like, LikeDto>();
            
            CreateMap<PostPhoto, PostPhotoDto>();

            //CreateMap<Post, PostDto>()
            //.ForMember(dest => dest.PostPhotos, opt => opt.MapFrom(m => m.PostPhotos))
            //.ForMember(dest => dest.Likes, opt => opt.MapFrom(m => m.Likes))
            //.ForMember(dest => dest.Comments, opt => opt.MapFrom(m => m.Comments));
            
            CreateMap<Entites.Models.Profile, ProfileDto>();
            CreateMap<RegistUserDto, User>();
        }
    }
}
