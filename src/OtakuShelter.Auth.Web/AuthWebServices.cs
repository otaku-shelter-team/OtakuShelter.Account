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

namespace OtakuShelter.Auth
{
	public static class OtakuShelterAuthServices
	{
		public static IServiceCollection AddWebServices(this IServiceCollection services, AuthWebConfiguration configuration)
		{
			services.AddCors();
			
			services.TryAddScoped<IPasswordHasher<Identity>, PasswordHasher<Identity>>();
			
			services
				.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization()
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddIdentityController())
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
			
			return services;
		}
		
		public static void EnsureDatabaseMigrated(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				scope.ServiceProvider
					.GetRequiredService<AuthContext>()
					.Database
					.Migrate();
			}
		}
	}
}