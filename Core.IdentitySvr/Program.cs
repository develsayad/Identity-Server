

using Core.IdentitySvr;
using IdentityServer4.Models;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddIdentityServer()
//    .AddDeveloperSigningCredential()
//    .AddInMemoryApiResources(Config.GetAllApiResources())
//    .AddInMemoryClients(Config.GetClients());


builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    //.AddInMemoryIdentityResources(Config.IdentityResources)
    //.AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    //.AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();



var app = builder.Build();
app.UseRouting();
app.UseIdentityServer();


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("hello world");
//    });
//});

app.MapGet("/", () => "Hello World!");
app.Run();
