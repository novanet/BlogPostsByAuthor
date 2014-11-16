using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggPostsByAuthor.AuthorData
{
    [ContractClass(typeof(ContractForIAuthenticate))]
    public interface IAuthenticate
    {
        Task<AuthenticationData> Authenticate(BlogLoginSettings loginSettings);
    }

    [ContractClassFor(typeof(IAuthenticate))]
    public abstract class ContractForIAuthenticate : IAuthenticate
    {

        public Task<AuthenticationData> Authenticate(BlogLoginSettings loginSettings)
        {
            Contract.Requires<ArgumentNullException>(loginSettings != null);
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(loginSettings.Url));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(loginSettings.UserName));
            Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(loginSettings.Password));

            return Task.FromResult(new AuthenticationData());
        }
    }

}
