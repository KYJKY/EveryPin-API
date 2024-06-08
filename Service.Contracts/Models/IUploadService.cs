using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface IUploadService
    {
        public string UploadTest(UploadImageInputDto UploadImageInputDto);
    }
}
