using IdentityServer4;
using IdentityServer4.Models;

namespace CourtAuthIdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
       new IdentityResource[]
       {
            new IdentityResources.OpenId(), // Required for OpenID Connect
            new IdentityResources.Profile() // Includes profile claims like name, email, etc.
       };
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId = "angular-client",
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = { "http://localhost:4200/callback" },
                PostLogoutRedirectUris = { "http://localhost:4200/" },
                AllowedCorsOrigins = { "http://localhost:4200" },
                AllowedScopes = new HashSet<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            }
        };

        //public static IEnumerable<ApiResource> ApiResources => new[]
        //    {
        //new ApiResource("api1", "My API") { Scopes = { "todo.read" } }
        //    };

    }
}
