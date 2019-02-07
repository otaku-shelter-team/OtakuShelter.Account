using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Auth
{
	public class IdentityController : ControllerBase
	{
		private readonly AuthContext context;
		private readonly IPasswordHasher<Identity> hasher;
		private readonly AuthWebConfiguration configuration;

		public IdentityController(
			AuthContext context,
			IPasswordHasher<Identity> hasher,
			IOptions<AuthWebConfiguration> configuration)
		{
			this.context = context;
			this.hasher = hasher;
			this.configuration = configuration.Value;
		}

		public async Task Create(CreateIdentityViewModel model)
		{
			await model.Create(context, hasher);

			await context.SaveChangesAsync();
		}

		public async Task<ReadIdentityResultViewModel> Read(ReadIdentityViewModel model)
		{
			var identity = await model.Read(context, hasher);
			
			var result = new ReadIdentityResultViewModel();

			await result.Load(identity, configuration);

			return result;
		}

		public async Task Update(UpdateIdentityViewModel model)
		{
			var identityId = int.Parse(ControllerContext.HttpContext.User.Identity.Name);

			await model.Update(context, identityId, hasher);

			await context.SaveChangesAsync();
		}

		public async Task Delete(DeleteIdentityViewModel model)
		{
			var identityId = int.Parse(ControllerContext.HttpContext.User.Identity.Name);

			await model.Delete(context, identityId);

			await context.SaveChangesAsync();
		}
	}
}