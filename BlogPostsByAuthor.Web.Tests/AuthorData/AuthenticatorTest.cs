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
    public class AuthenticatorTest
    {
        [TestMethod, Ignore] //this test can be run to verify authentication, once proper BlogLoginSettings are added
        public void WhenAuthenticate()
        {
            var authenticator = new Authenticator();
            var task = authenticator.Authenticate(new BlogLoginSettings());
            task.Wait();
            task.Result.AccessToken.Should().NotBeEmpty();
        }
    }
}
