using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BloggPostsByAuthor.AuthorData
{
    public class AuthorPostService
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly AuthorPostsFetcher _postFetcher;
        private readonly BlogLoginSettings _loginSettings;

        public AuthorPostService(BlogLoginSettings loginSettings, 
            ITokenProvider tokenProvider, AuthorPostsFetcher postFetcher)
        {
            Contract.Requires(loginSettings != null);
            Contract.Requires(tokenProvider != null);
            Contract.Requires(postFetcher != null);

            Contract.Requires(!string.IsNullOrEmpty(loginSettings.Url));
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.UserName));
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.Password));
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.ClientSecret));

            _loginSettings = loginSettings;
            _tokenProvider = tokenProvider;
            _postFetcher = postFetcher;
        }

        public async Task<IEnumerable<Post>> GetPosts(string authorSlug)
        {
            Contract.Requires(authorSlug != null);

            var token = await _tokenProvider.GetToken(_loginSettings);
            return await _postFetcher.Fetch(_loginSettings.Url, token, authorSlug);
        }
    }
}