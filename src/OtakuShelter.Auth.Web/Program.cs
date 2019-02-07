using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OtakuShelter.Auth.Web;
using Phema.Configuration;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Auth
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var app = new WebHostBuilder()
				.UseKestrel()
				.UseWebRoot(Directory.GetCurrentDirectory())
				.ConfigureAppConfiguration((context, builder) =>
					builder.AddYamlFile("appsettings.yml")
						.SetBasePath(context.HostingEnvironment.WebRootPath))
				.ConfigureLogging((context, builder) =>
					builder.AddConsole()
						.SetMinimumLevel(LogLevel.Warning))
				.UseStartup<Startup>()
				.UseConfiguration<AuthWebConfiguration>()
				.Build();

			await app.RunAsync();
		}
	}
}