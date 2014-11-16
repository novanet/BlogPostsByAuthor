using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace BloggPostsByAuthor.AuthorData
{
    public class TokenCache : ITokenProvider
    {
        private const string cache_key = "authentication_data";

        private readonly IAuthenticate _authenticator;

        public TokenCache(IAuthenticate authenticator)
        {
            _authenticator = authenticator;
        }

        public async Task<string> GetToken(BlogLoginSettings loginSettings)
        {
            var authData = GetAuthenticationData();
            if (authData != null)
                return authData.AccessToken;

            authData = await _authenticator.Authenticate(loginSettings);
            if (string.IsNullOrEmpty(authData.AccessToken))
                return "";

            var cache = MemoryCache.Default;
            cache.Set(cache_key, authData, DateTimeOffset.Now.AddSeconds(authData.ExpiresIn - 60));
            return authData.AccessToken;
        }

        private AuthenticationData GetAuthenticationData()
        {
            Contract.Assume(MemoryCache.Default != null);
            var data = MemoryCache.Default[cache_key] as AuthenticationData;
            return data == null || string.IsNullOrEmpty(data.AccessToken) ?
                null : data;
        }
    }
}