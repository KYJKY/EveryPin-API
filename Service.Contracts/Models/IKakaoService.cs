using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts.Models
{
    public interface IKakaoService
    {
        Task<string> GetKakaoAccessToken(string code);
        Task<KakaoLoginDto> GetUserInfo(string accessToken);
    }
}
