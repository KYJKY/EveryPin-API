using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record CommentDto(Guid Id, Guid UserId, string? CommentMessage, DateTime? CreatedDate)
    {
        //public Guid Id { get; set; }
        //public Guid UserId { get; set; }
        //public string? CommentMessage { get; set; }
        //public DateTime? CreatedDate { get; set; }
    }
}
