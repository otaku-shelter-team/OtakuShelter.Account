using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Account
{
	public class AccountContextFactory : IDesignTimeDbContextFactory<AccountContext>
	{
		public AccountContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			ConfigureBuilder(configurationBuilder, Directory.GetCurrentDirectory());
			var configuration = configurationBuilder.Build();
			
			var database = configuration.GetSection("database").Get<AccountContextConfiguration>();

			var options = new DbContextOptionsBuilder<AccountContext>();
			ConfigureContext(options, database);
			
			return new AccountContext(options.Options);
		}

		public static void ConfigureBuilder(IConfigurationBuilder builder, string path)
		{
			builder.SetBasePath(path)
				.AddYamlFile("appsettings.yml")
				.AddEnvironmentVariables("OTAKUSHELTER:");
		}

		public static void ConfigureContext(DbContextOptionsBuilder options, AccountContextConfiguration accountContext)
		{
			options.UseNpgsql(accountContext.ConnectionString, 
					builder => builder.MigrationsHistoryTable(accountContext.MigrationsTable))
				.ConfigureWarnings(builder => builder.Throw(RelationalEventId.QueryClientEvaluationWarning));
		}
	}
}