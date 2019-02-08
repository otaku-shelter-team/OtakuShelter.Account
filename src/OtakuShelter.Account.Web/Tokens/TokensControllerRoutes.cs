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

				controller.AddRoute("refresh", c => c.Refresh(From.Body<RefreshTokenViewModel>()))
					.HttpPost();
			});
			
			return builder;
		}
	}
}