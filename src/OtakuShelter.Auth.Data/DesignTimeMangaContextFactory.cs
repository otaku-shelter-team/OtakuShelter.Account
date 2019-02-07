using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OtakuShelter.Auth;
using Phema.Configuration.Yaml;

namespace OtakuShelter.Manga
{
	public class DesignTimeMangaContextFactory : IDesignTimeDbContextFactory<AuthContext>
	{
		public AuthContext CreateDbContext(string[] args)
		{
			var configurationBuilder = new ConfigurationBuilder();
			CreateConfigurationBuilderConfiguration(Directory.GetCurrentDirectory())(configurationBuilder);
			var configuration = configurationBuilder.Build();
			
			var database = configuration.GetSection("database").Get<AuthDatabaseConfiguration>();

			var optionsBuilder = new DbContextOptionsBuilder<AuthContext>();
			CreateDbContextOptionsConfiguration(database)(optionsBuilder);
			var options = optionsBuilder.Options;
			
			return new AuthContext(options);
		}

		public static Action<IConfigurationBuilder> CreateConfigurationBuilderConfiguration(string path)
		{
			return builder => builder
				.SetBasePath(path)
				.AddYamlFile("appsettings.yml");
		}
		
		public static Action<DbContextOptionsBuilder> CreateDbContextOptionsConfiguration(
			AuthDatabaseConfiguration database)
		{
			return options => options.UseNpgsql(database.ConnectionString, builder =>
					builder.MigrationsHistoryTable(database.MigrationsTable))
				.UseLazyLoadingProxies();
		}
	}
}