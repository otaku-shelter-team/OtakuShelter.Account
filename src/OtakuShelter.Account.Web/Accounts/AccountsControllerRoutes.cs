using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class AccountsControllerRoutes
	{
		public static IRoutingBuilder AddAccountsController(this IRoutingBuilder builder, AccountRoleConfiguration roles)
		{
			builder.AddController<AccountsController>(controller =>
			{
				controller.AddRoute("accounts", c => c.Create(From.Body<CreateAccountViewModel>()))
					.HttpPost();

				controller.AddRoute("accounts", c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("accounts", c => c.Update(From.Body<UpdateAccountViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("accounts", c => c.Delete(From.Any<DeleteAccountViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("admin/accounts", c => c.AdminRead(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}",
						c => c.AdminUpdateById(From.Route<int>(), From.Body<AdminUpdateByIdAccountViewModel>()))
					.HttpPut()
					.Authorize(roles.Admin);

				controller.AddRoute("admin/accounts/{accountId}", c => c.AdminDeleteById(From.Route<AdminDeleteByIdAccountViewModel>()))
					.HttpDelete()
					.Authorize(roles.Admin);
			});
			
			return builder;
		}
	}
}