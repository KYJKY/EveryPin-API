using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record ProfileDto(Guid Id, string? Name, string? SelfIntroduction, string? PhotoUrl, Guid UserId, DateTime? UpdatedDate, DateTime? CreatedDate);
}
