

using Core.IdentitySvr;
using Core.IdentitySvr.Models;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System.Reflection;




var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
const string connectionString = @"Data Source=DESKTOP-APPM9TF;database=IdentityServer4.Quickstart.EntityFramework-4.0.0;trusted_connection=yes;";

//builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
//    .AddEntityFrameworkStores< ApplicationDbContext>


builder.Services.AddControllersWithViews();

builder.Services.AddIdentityServer()
    .AddTestUsers(Config.TestUsers)
    .AddConfigurationStore(options => {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
               sql => sql.MigrationsAssembly(migrationsAssembly));
    })
     .AddOperationalStore(options =>
     {
         options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
             sql => sql.MigrationsAssembly(migrationsAssembly));
     });


//.AddInMemoryClients(Config.Clients)
//.AddInMemoryIdentityResources(Config.IdentityResources)
////.AddInMemoryApiResources(Config.ApiResources)
//.AddInMemoryApiScopes(Config.ApiScopes)

//.AddDeveloperSigningCredential();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");
app.Run();
