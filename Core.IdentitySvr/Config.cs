
using IdentityServer4.Models;
using System.Runtime.Intrinsics.Arm;

namespace Core.IdentitySvr
{
    public class Config
    {


        public static IEnumerable<ApiResource> GetAllApiResources()
        {

            return new List<ApiResource>
            {
                new ApiResource{  Name="Api", DisplayName="test api"}
            };
        }


        public static IEnumerable<Client> GetClients()
        {

            return new List<Client> { new Client {
            ClientId="client",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets= {
                new Secret("secret".Sha256())
                },
             AllowedScopes={ "api"}
            } };
        }


    }
}
