using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Blob
{
    public class BlobResponseDto
    {
        public BlobDto Blob { get; set; }
        public string? Message { get; set; }
        public bool Error {  get; set; }

        public BlobResponseDto()
        {
            Blob = new BlobDto();
        }
    }
}
