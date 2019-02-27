using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentsApp.DataSeeding;

namespace StudentsApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IWebHost host = CreateWebHostBuilder(args).Build();

			IHostingEnvironment env = host.Services.GetService<IHostingEnvironment>();

			using (IServiceScope scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					StudentAppContext context = services.GetRequiredService<StudentAppContext>();
					context.Database.EnsureCreated();
					DataDbInitializer.Seed(context);
				}
				catch (Exception ex)
				{
					ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

			host.Run();
		}
		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
