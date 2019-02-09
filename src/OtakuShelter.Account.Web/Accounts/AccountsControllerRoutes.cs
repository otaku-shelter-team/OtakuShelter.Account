using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class AccountsControllerRoutes
	{
		public static IRoutingBuilder AddAccountsController(this IRoutingBuilder builder)
		{
			builder.AddController<AccountsController>("accounts", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateAccountViewModel>()))
					.HttpPost();

				controller.AddRoute(c => c.Read(From.Query<FilterViewModel>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("{accountId}", c => c.ReadById(From.Route<int>()))
					.HttpGet()
					.Authorize("admin");
				
				controller.AddRoute("self", c => c.ReadSelf())
					.HttpGet()
					.Authorize();

				controller.AddRoute(c => c.Update(From.Body<UpdateAccountViewModel>()))
					.HttpPut()
					.Authorize();

				controller.AddRoute("{accountId}", c => c.UpdateById(From.Route<int>(), From.Body<UpdateByIdAccountViewModel>()))
					.HttpPut()
					.Authorize("admin");

				controller.AddRoute(c => c.Delete(From.Any<DeleteAccountViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute("{accountId}", c => c.DeleteById(From.Route<DeleteByIdAccountViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}