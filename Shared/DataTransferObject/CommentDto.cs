using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record CommentDto()
    {
        public int Id { get; init; }
        public Guid UserId { get; init; }
        public string? CommentMessage { get; init; }
        public DateTime? CreatedDate { get; init; }
    }
}
