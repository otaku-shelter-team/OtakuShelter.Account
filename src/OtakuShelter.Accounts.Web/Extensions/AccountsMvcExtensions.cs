using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Phema.Routing;

namespace OtakuShelter.Accounts
{
	public static class AccountsMvcExtensions
	{
		public static IServiceCollection AddAccountsMvc(
			this IServiceCollection services,
			AccountsRoleConfiguration roles)
		{
			services.AddMvcCore()
				.AddJsonFormatters()
				.AddAuthorization(options =>
					options.AddPolicy("admin", builder => builder.RequireRole(roles.Admin)))
				.AddApiExplorer()
				.AddPhemaRouting(routing => routing.AddAccountsController(roles)
					.AddTokensController(roles)
					.AddVersionController())
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			return services;
		}
	}
}