using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net.Http;

namespace BloggPostsByAuthor.AuthorData
{
    public class AuthenticationRequest
    {
        private const string tokenPath = "ghost/api/v0.1/authentication/token";

        private readonly string _username;
        private readonly string _password;

        public AuthenticationRequest(string username, string password)
        {
            _username = username;
            _password = password;
        }
            
        public HttpRequestMessage Request
        {
            get
            {
                Contract.Ensures(Contract.Result<System.Net.Http.HttpRequestMessage>() != null);

                return new HttpRequestMessage(HttpMethod.Post, tokenPath)
                {
                    Content = CreateRequestContent(),
                };
            }
        }

        private HttpContent CreateRequestContent()
        {
            return new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", _username),
                    new KeyValuePair<string, string>("password", _password),
                    new KeyValuePair<string, string>("client_id", "ghost-admin"),
                });
        }
    }
}