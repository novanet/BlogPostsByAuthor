using BloggPostsByAuthor.AuthorData;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace BloggPostsByAuthor.Tests
{
    [TestClass]
    public class TokenCacheTest
    {
        [TestMethod]
        public void GetTokenReturnsATokenWhenAuthenticated()
        {
            var authenticator = A.Fake<IAuthenticate>();
            A.CallTo(() => authenticator.Authenticate(A<BlogLoginSettings>._))
                .Returns(new AuthenticationData { AccessToken = "123" });
            var cache = new TokenCache(authenticator);
            var task = cache.GetToken(new BlogLoginSettings { Url = "test", UserName = "me", Password = "password" });
            task.Wait();
            task.Result.Should().NotBeNullOrWhiteSpace();
            task.Result.Should().Be("123");
        }
    }
}
