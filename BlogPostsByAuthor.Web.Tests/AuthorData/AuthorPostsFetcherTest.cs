using BloggPostsByAuthor.AuthorData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace BloggPostsByAuthor.Tests.AuthorData
{
    [TestClass]
    public class AuthorPostsFetcherTest
    {
        [TestMethod, Ignore]
        public void CanRead()
        {
            var fetcher = new AuthorPostsFetcher();
            var resultTask = fetcher.Fetch("https://novanet-blog.ghost.io",
                "access-token", //access token
                "author-slug"); //author slug
            resultTask.Wait();
            var result = resultTask.Result.ToList();
            result.Count.Should().BeGreaterThan(0);
        }

        [TestMethod]
        public void Test()
        {
            var fetcher = new AuthorPostsFetcher();
            fetcher.Fetch(null, null, null);
        }
    }
}
