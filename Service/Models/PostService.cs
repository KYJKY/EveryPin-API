using AutoMapper;
using Contracts.Repository;
using Entites.Exceptions;
using Entites.Models;
using ExternalLibraryService;
using Microsoft.Extensions.Logging;
using Service.Models;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using Shared.DataTransferObject.OutputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service.Contracts.Models
{
    internal sealed class PostService : IPostService
    {
        private readonly ILogger<PostService> _logger;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly BlobHandlingService _blobHandlingService;

        public PostService(ILogger<PostService> logger, IRepositoryManager repository, IMapper mapper, BlobHandlingService blobHandlingService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _blobHandlingService = blobHandlingService;
        }

        public async Task<IEnumerable<PostDto>> GetAllPost(bool trackChanges)
        {
            var posts = await _repository.Post.GetAllPost(trackChanges);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postsDto;
        }

        public async Task<PostDto> GetPost(int postId, bool trackChanges)
        {
            var post = await _repository.Post.GetPostById(postId, trackChanges);

            if (post is null) 
                throw new PostNotFoundException(postId);

            var postDto = _mapper.Map<PostDto>(post);

            return postDto;
        }

        public async Task<IEnumerable<PostDto>> GetSearchPost(double x, double y, double range, bool trackChanges)
        {
            var posts = await _repository.Post.GetSearchPost(x, y, range, trackChanges);
            //var users = await _repository.User.GetAllUser(trackChanges);
            //var joinposts = posts.Join(
            //                    users,
            //                    post => post.UserId,
            //                    user => user.Id,
            //                    (post, user) => new GetSearchPostOutputDto
            //                    {
            //
            //                    }
            //                    );

            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);

            return postsDto;
        }

        public async Task<PostDto> CreatePost(CreatePostDto post)
        {
            var postEntity = _mapper.Map<Post>(post);
            List<PostPhoto> postPhotos = new();
            bool isUploadSuccess = false;

            if (post.PhotoFiles != null)
            {
                var postPhotoId = await _repository.PostPhoto.GetLatestPostPhotoId();

                foreach (var photo in post.PhotoFiles)
                {
                    var result = await _blobHandlingService.UploadPostPhotoAsync(++postPhotoId, photo);
            
                    if (result.Error)
                    {
                        isUploadSuccess = false;
                        break;
                    }
                    else
                    {
                        var postPhoto = new PostPhoto
                        {
                            photoUrl = result.Blob.Uri
                        };
                        postPhotos.Add(postPhoto);

                        isUploadSuccess = true;
                    }
                }
            }

            if (isUploadSuccess)
            {
                postEntity.PostPhotos = postPhotos;
                _repository.Post.CreatePost(postEntity);
                await _repository.SaveAsync();
            }

            var postToReturn = _mapper.Map<PostDto>(postEntity);

            return postToReturn;
        }
    }
}

