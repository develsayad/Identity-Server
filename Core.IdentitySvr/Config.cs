
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Runtime.Intrinsics.Arm;

namespace Core.IdentitySvr
{
    public class Config
    {

        public static IEnumerable<Client> Clients =>
            new List<Client> { new Client {
            ClientId="movieClient",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets= {
                new Secret("secret".Sha256())
                },
             AllowedScopes={ "movieApi" }
            } };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] { new ApiScope("movieApi", "Movie Api") };

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>{};



        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] { };

        public static List<TestUser> TestUsers =>
            new List<TestUser> { };




    }
}
