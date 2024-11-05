using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject;

public record CommentDto(int CommentId, int PostId, Guid UserId, string? CommentMessage, DateTime? CreatedDate);
