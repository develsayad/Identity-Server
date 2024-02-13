
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Runtime.Intrinsics.Arm;

namespace Core.IdentitySvr
{
    public class Config
    {

        public static IEnumerable<Client> Clients =>
            new List<Client> { new Client {
            ClientId="client",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets= {
                new Secret("secret".Sha256())
                },
             AllowedScopes={ "api"}
            } };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] { };

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource>
            {
                new ApiResource{  Name="Api", DisplayName="test api"}
            };



        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] { };

        public static List<TestUser> TestUsers =>
            new List<TestUser> { };




    }
}
