using BloggPostsByAuthor.AuthorData;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Threading.Tasks;

namespace BlogPostsByAuthor.Web.Controllers
{
    public class HomeController : Controller
    {
        [ContractVerification(false)]
        public async Task<ActionResult> Index(string authorSlug = "olav-nybo")
        {
            var posts = (await new AuthorPostService(CreateLoginSettings(),
                new TokenCache(new Authenticator()),
                new AuthorPostsFetcher()).GetPosts(authorSlug)).ToList();
            return View(posts);
        }

        private BlogLoginSettings CreateLoginSettings()
        {
            return new BlogLoginSettings
            {
                Url = ConfigurationManager.AppSettings["BlogUrl"],
                UserName = ConfigurationManager.AppSettings["UserName"],
                Password = ConfigurationManager.AppSettings["Password"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
            };
        }
    }
}