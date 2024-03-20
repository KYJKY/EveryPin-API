using Microsoft.Extensions.Configuration;
using Service.Contracts.Models;
using Shared.DataTransferObject;
using Shared.DataTransferObject.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Models
{
    public class KakaoService : IKakaoService
    {
        private readonly IConfiguration _configuration;

        public KakaoService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<string> GetKakaoAccessToken(string code)
        {
            string accessToken = "";
            string refreshToken = "";

            string redirectURI = "http://localhost:5283/api/kakao/kakao-login";
            string clientId = _configuration.GetConnectionString("kakao-rest-api-key");
            string requestURL = "https://kauth.kakao.com/oauth/token";

            string queryString = $"?grant_type=authorization_code" +
                                 $"&client_id={clientId}" +
                                 $"&redirect_uri={redirectURI}" +
                                 $"&code={code}";

            // HTTP 요청 생성
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestURL + queryString);
            request.Method = "POST";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
                {
                    int responseCode = (int)response.StatusCode;

                    if (responseCode == 200)
                    {
                        string jsonResponse;

                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            jsonResponse = reader.ReadToEnd();

                            JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse);
                            JsonElement root = jsonDocument.RootElement;

                            accessToken = root.GetProperty("access_token").GetString();
                            refreshToken = root.GetProperty("refresh_token").GetString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return accessToken;
        }

        public async Task<KakaoLoginDto> GetUserInfo(string accessToken)
        {
            string postURL = "https://kapi.kakao.com/v2/user/me";

            // HTTP 요청 생성
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postURL);
            request.Method = "POST";
            request.Headers["Authorization"] = "Bearer " + accessToken;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            {
                int responseCode = (int)response.StatusCode;

                if (responseCode == 200)
                {
                    string jsonResponse;

                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        jsonResponse = reader.ReadToEnd();

                        JsonDocument jsonDocument = JsonDocument.Parse(jsonResponse);
                        JsonElement root = jsonDocument.RootElement;

                        JsonElement kakao_account = root.GetProperty("kakao_account");
                        JsonElement profile = kakao_account.GetProperty("profile");

                        string nickname = profile.GetProperty("nickname").GetString();
                        string email = kakao_account.GetProperty("email").GetString();

                        return new KakaoLoginDto() { UserNickName =  nickname };
                    }
                }
                else
                {
                    throw new Exception("Kakao 유저 정보를 불러올 수 없습니다.");
                }
            }
        }
    }
}
