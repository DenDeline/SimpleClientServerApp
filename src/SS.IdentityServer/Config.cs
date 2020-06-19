using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;

namespace SS.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources() =>
            new List<ApiResource>
            {
                new ApiResource("accounts", "Accounts API")
                {
                    Scopes = { "accounts.read", "accounts.write", "accounts.delete" }
                }
            };

        public static IEnumerable<Client> Clients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "AccountsApi",
                    ClientSecrets = { new Secret("AccountsApi.SecretKey".ToSha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials
                }
            };

        public static IEnumerable<ApiScope> ApiScopes() => 
            new List<ApiScope>
            {
                new ApiScope("accounts.read"),
                new ApiScope("accounts.write"),
                new ApiScope("accounts.delete")
            };

        public static IEnumerable<IdentityResource> IdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
