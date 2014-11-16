using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BloggPostsByAuthor.AuthorData
{
    public class AuthorPostsFetcher
    {
        public async Task<IEnumerable<Post>> Fetch(string url, string accessToken, string author)
        {
            Contract.Requires(!string.IsNullOrEmpty(url));
            Contract.Requires(!string.IsNullOrEmpty(accessToken));
            Contract.Requires(!string.IsNullOrEmpty(author));

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/ghost/api/v0.1/posts/?author=" + author);

                if (response.IsSuccessStatusCode)
                {
                    dynamic json = JObject.Parse(await response.Content.ReadAsStringAsync());
                    return ConvertToPosts(json.posts);
                }
                return new List<Post>();
            }
        }

        private IEnumerable<Post> ConvertToPosts(dynamic posts)
        {
            foreach (var post in posts)
            {
                yield return ((JObject)post).ToObject<Post>();
            }
        }
    }
}