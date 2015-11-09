using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace BloggPostsByAuthor.AuthorData
{
    public class Authenticator : IAuthenticate
    {
        public Authenticator()
        {
        }

        public async Task<AuthenticationData> Authenticate(BlogLoginSettings loginSettings)
        {
            Contract.Ensures(Contract.Result<AuthenticationData>() != null);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(loginSettings.Url);

                var response = await client.SendAsync(
                        new AuthenticationRequest(loginSettings.UserName, loginSettings.Password, loginSettings.ClientSecret).Request
                );
                if (response.IsSuccessStatusCode)
                {
                    dynamic json = JValue.Parse(await response.Content.ReadAsStringAsync());
                    return new AuthenticationData
                    {
                        AccessToken = json.access_token,
                        RefreshToken = json.refresh_token,
                        ExpiresIn = json.expires_in,
                        TokenType = json.token_type,
                    };
                }
                return new AuthenticationData();
            }
        }        
    }
}