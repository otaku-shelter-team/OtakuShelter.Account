using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Phema.Routing;
using Swashbuckle.AspNetCore.Swagger;

namespace OtakuShelter.Account
{
	public static class AccountWebServices
	{
		public static IServiceCollection AddWebServices(this IServiceCollection services, AccountWebConfiguration configuration)
		{
			services.AddCors();
			
			services.TryAddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();
			
			services
				.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization()
				.AddApiExplorer()
				.AddPhemaRouting(routing => 
					routing.AddAccountsController()
						.AddTokensController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddAuthorization();
			
			var secret = Encoding.ASCII.GetBytes(configuration.Secret);
			services.AddAuthentication(x =>
				{
					x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(x =>
				{
					x.RequireHttpsMetadata = false;
					x.SaveToken = true;
					x.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(secret),
						ValidateIssuer = true,
						ValidIssuer = configuration.Issuer,
						ValidateAudience = true,
						ValidAudience = configuration.Audience
					};
				});
			
			services.AddSwaggerGen(options => 
				options.SwaggerDoc("v1", new Info { Title = "OtakuShelter Account API", Version = "v1" }));
			
			return services;
		}
		
		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<AccountContext>()
					.Database
					.Migrate();
			}
		}
	}
}