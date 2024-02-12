using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public record ProfileDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? SelfIntroduction { get; init; }
        public string? PhotoUrl { get; init; }
        public Guid UserId { get; init; }
        public DateTime? UpdatedDate { get; init; }
        public DateTime? CreatedDate { get; init; }
    }
}
