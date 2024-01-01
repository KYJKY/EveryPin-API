using Contracts.Repository;
using Service.Contracts;
using Service.Contracts.Models;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICommentService> _commentService;
        private readonly Lazy<ILikeService> _likeService;
        private readonly Lazy<IPostPhotoService> _postPhotoService;
        private readonly Lazy<IPostService> _postService;
        private readonly Lazy<IProfileService> _profileService;
        //private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _commentService = new Lazy<ICommentService>(() => new CommentService(repositoryManager));
            _likeService = new Lazy<ILikeService>(() => new LikeService(repositoryManager));
            _postPhotoService = new Lazy<IPostPhotoService>(() => new PostPhotoService(repositoryManager));
            _postService = new Lazy<IPostService>(() => new PostService(repositoryManager));
            _profileService = new Lazy<IProfileService>(() => new ProfileService(repositoryManager));
            //_userService = new Lazy<IUserService>(() => new UserService(repositoryManager));
        }

        public ICommentService CommentService => _commentService.Value;
        public ILikeService LikeService => _likeService.Value;
        public IPostPhotoService PostPhotoService => _postPhotoService.Value;
        public IPostService PostService => _postService.Value;
        public IProfileService ProfileService => _profileService.Value;
        //public IUserService UserService => _userService.Value;
    }
}
