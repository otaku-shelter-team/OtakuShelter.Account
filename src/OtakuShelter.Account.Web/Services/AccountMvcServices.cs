using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class AccountMvcServices
	{
		public static IServiceCollection AddMvcServices(
			this IServiceCollection services,
			AccountRoleConfiguration roles)
		{
			services
				.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing =>
					routing.AddAccountsController()
						.AddTokensController()
						.AddRolesController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}