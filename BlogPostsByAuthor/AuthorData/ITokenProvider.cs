using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BloggPostsByAuthor.AuthorData
{
    [ContractClass(typeof(ContractForITokenProvider))]
    public interface ITokenProvider
    {
        Task<string> GetToken(BlogLoginSettings loginSettings);
    }

    [ContractClassFor(typeof(ITokenProvider))]
    public abstract class ContractForITokenProvider : ITokenProvider
    {
        public Task<string> GetToken(BlogLoginSettings loginSettings)
        {
            Contract.Requires<ArgumentNullException>(loginSettings != null);
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.Url));
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.UserName));
            Contract.Requires(!string.IsNullOrEmpty(loginSettings.Password));

            return Task.FromResult("");
        }
    }
}