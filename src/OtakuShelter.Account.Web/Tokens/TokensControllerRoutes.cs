using Microsoft.AspNetCore.Identity;

using Phema.Routing;

namespace OtakuShelter.Account
{
	public static class TokensControllerRoutes
	{
		public static IRoutingBuilder AddTokensController(this IRoutingBuilder builder)
		{
			builder.AddController<TokensController>("tokens", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateTokenViewModel>()))
					.HttpPost();

				controller.AddRoute(c => c.Read())
					.HttpGet()
					.Authorize();

				controller.AddRoute("{tokenId}", c => c.Delete(From.Route<DeleteTokenViewModel>()))
					.HttpDelete()
					.Authorize();

				controller.AddRoute(c => c.Refresh(From.Body<RefreshTokenViewModel>()))
					.HttpPut();

				controller.AddRoute("admin/{accountId}", c => c.AdminReadById(From.Route<int>()))
					.HttpGet()
					.Authorize("admin");

				controller.AddRoute("admin/{tokenId}",
						c => c.AdminDeleteById(From.Route<AdminDeleteByIdTokenViewModel>()))
					.HttpDelete()
					.Authorize("admin");
			});
			
			return builder;
		}
	}
}