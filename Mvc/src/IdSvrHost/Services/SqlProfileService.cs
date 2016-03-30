using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;

namespace IdSvrHost.Services
{
    public class SqlProfileService: IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //throw new NotImplementedException();

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //throw new NotImplementedException();

            return Task.FromResult(0);
        }
    }
}
