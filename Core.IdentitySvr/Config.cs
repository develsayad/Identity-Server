
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;

namespace Core.IdentitySvr
{
    public class Config
    {

        public static IEnumerable<Client> Clients =>
            new List<Client> { 
            
                // api client
                new Client {
            ClientId="movieClient",
            AllowedGrantTypes=GrantTypes.ClientCredentials,
            ClientSecrets= {new Secret("secret".Sha256())},
             AllowedScopes={ "movieApi" }
            } ,
            
            // mvc client..
            
                new Client{
                    ClientId="movies_mvc_client",
                    ClientName="movie mvc web app",
                    AllowedGrantTypes=GrantTypes.Code,
                    AllowRememberConsent=false,
                     RedirectUris=new List<string>(){
                     "https://localhost:5002/signin-oidc"  // client app port
                     },
                     PostLogoutRedirectUris=new List<string>{
                     "https://localhost:5002/signout-callback-oidc" //
                     },
                     ClientSecrets= {new Secret("secret".Sha256())},
                     AllowedScopes= new List<string>{
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile

                     }
                }

            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] { new ApiScope("movieApi", "Movie Api") };

        public static IEnumerable<ApiResource> ApiResources =>
        new List<ApiResource> { };



        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] {
            new IdentityResources.OpenId(),
             new IdentityResources.Profile()
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser> {

            new TestUser{
                Username="mohamed", 
                Password="P@ssw0rd", 
                SubjectId="10215-4548fdre8454re-545err45",
                 Claims= new List<Claim>{ 
                 new Claim(JwtClaimTypes.GivenName,"mohamed"),
                 new Claim(JwtClaimTypes.FamilyName,"elsayad"),
                  
                 }
            
            }
            };




    }
}
