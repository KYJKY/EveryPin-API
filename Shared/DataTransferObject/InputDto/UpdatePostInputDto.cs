using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.InputDto;
public class UpdatePostInputDto
{
    public int PostId { get; set; }
    public string? PostContent { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public List<IFormFile>? PhotoFiles { get; set; }
    public DateTime? UpdateDate { get; set; }
}
