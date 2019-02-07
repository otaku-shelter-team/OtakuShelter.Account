using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Phema.Routing;

namespace OtakuShelter.Auth
{
	public static class IdentityControllerRoutes
	{
		public static IRoutingBuilder AddIdentityController(this IRoutingBuilder builder)
		{
			builder.AddController<IdentityController>("identities", controller =>
			{
				controller.AddRoute(c => c.Create(From.Body<CreateIdentityViewModel>()))
					.HttpPost();

				controller.AddRoute(c => c.Read(From.Query<ReadIdentityViewModel>()))
					.HttpGet();

				controller.AddRoute(c => c.Update(From.Body<UpdateIdentityViewModel>()))
					.HttpPut()
					.AddFilter(new AuthorizeFilter(new [] { new AuthorizeAttribute() }));

				controller.AddRoute(c => c.Delete(From.Any<DeleteIdentityViewModel>()))
					.HttpDelete()
					.AddFilter(new AuthorizeFilter(new[] { new AuthorizeAttribute() }));
			});
			
			return builder;
		}
	}
}