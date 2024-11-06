using Microsoft.AspNetCore.Http;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject;

public class CreatePostDto
{
    public string? PostContent { get; set; }
    public string? UserId { get; set; }
    public string? Address { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public List<IFormFile>? PhotoFiles { get; set; }

    public void SetInputDto(CreatePostInputDto inputDto)
    {
        PostContent = inputDto.PostContent;
        X = inputDto.X;
        Y = inputDto.Y;
        PhotoFiles = inputDto.PhotoFiles;
    }
}
