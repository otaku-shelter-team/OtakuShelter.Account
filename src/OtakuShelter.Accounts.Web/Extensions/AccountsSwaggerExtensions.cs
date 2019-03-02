using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace OtakuShelter.Accounts
{
	public static class AccountsSwaggerExtensions
	{
		public static IServiceCollection AddAccountsSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info {Title = "OtakuShelter Accounts API", Version = "v1"});

				options.AddSecurityDefinition("Bearer", new ApiKeyScheme
				{
					Description = "JWT Authorization header",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});

				options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
				{
					["Bearer"] = Enumerable.Empty<string>()
				});
			});

			return services;
		}

		public static IApplicationBuilder UseAccountsSwagger(this IApplicationBuilder app)
		{
			return app.UseSwagger()
				.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("v1/swagger.json", "OtakuShelter Accounts API v1");
					options.DocumentTitle = "OtakuShelter Accounts API";
					options.DocExpansion(DocExpansion.List);
				});
		}
	}
}