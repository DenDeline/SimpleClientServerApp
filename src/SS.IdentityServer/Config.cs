using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace SS.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {

            };

        public static IEnumerable<ApiScope> ApiScopes => 
            new List<ApiScope>
            {
                
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {

            };
    }
}
