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
            CreateMap<Comment, CommentDto>();
            CreateMap<Like, LikeDto>();
            CreateMap<Post, PostDto>();
            //CreateMap<Post, PostDto>()
            //.ForMember(dest => dest.PostPhotos, opt => opt.MapFrom(m => m.PostPhotos))
            //.ForMember(dest => dest.Likes, opt => opt.MapFrom(m => m.Likes))
            //.ForMember(dest => dest.Comments, opt => opt.MapFrom(m => m.Comments));
            CreateMap<PostPhoto, PostPhotoDto>();
            CreateMap<Entites.Models.Profile, ProfileDto>();
            CreateMap<RegistUserDto, User>();
        }
    }
}
