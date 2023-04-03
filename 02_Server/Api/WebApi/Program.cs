using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Webapi
{
	public class Program
	{
		public static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
			
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				
				try
				{

					//TODO: Registrar aqui servicios de insercion de registros iniciales
					//var userManager = services.GetRequiredService<UserManager<AplicationUser>>();
					//var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
					//await DefaultRoles.SeedAsync(userManager, roleManager);
					//await DefaultRootUser.SeedAsync(userManager, roleManager);
					//await DefaultAdminUser.SeedAsync(userManager, roleManager);
				}
				catch (Exception ex)
				{
					throw;
				}
			}

			host.Run();
            return Task.CompletedTask;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					
					webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                              .AddEnvironmentVariables();
                    });
                    webBuilder.ConfigureServices((hostingContext, services) =>
                    {
                        services.AddControllers().AddJsonOptions(options =>
                        {
                            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                        });
                    });
                });
   
	}
}
