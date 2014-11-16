using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Mvc;

namespace BlogPostsByAuthor.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            Contract.Requires(filters != null);

            filters.Add(new HandleErrorAttribute());
        }
    }
}
