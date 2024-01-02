﻿using Service.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        ICommentService CommentService { get; }
        ILikeService LikeService { get; }
        IPostPhotoService PostPhotoService { get; }
        IPostService PostService { get; }
        IProfileService ProfileService { get; }
        //IUserService UserService { get; }
        IAuthenticationService AuthenticationService { get; }
    }

}
