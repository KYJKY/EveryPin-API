using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.InputDto
{
    public class UploadImageInputDto
    {
        public string FileName { get; set; } = null!;
        public Stream ImageStream { get; set; } = null!;
    }
}
