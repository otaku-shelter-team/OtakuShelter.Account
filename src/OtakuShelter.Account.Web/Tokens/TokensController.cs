using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Account
{
	public class TokensController : ControllerBase
	{
		private readonly AccountContext context;
		private readonly IPasswordHasher<Account> hasher;
		private readonly AccountWebConfiguration configuration;

		public TokensController(AccountContext context, IPasswordHasher<Account> hasher, IOptions<AccountWebConfiguration> configuration)
		{
			this.context = context;
			this.hasher = hasher;
			this.configuration = configuration.Value;
		}

		public async Task<TokenViewModel> Create(CreateTokenViewModel model)
		{
			var token = await model.Create(context, hasher, configuration, HttpContext);

			await context.SaveChangesAsync();

			return token;
		}

		public async Task<ReadTokenViewModel> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var model = new ReadTokenViewModel();

			await model.Load(context, accountId);

			return model;
		}

		public async Task Delete(DeleteTokenViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);

			await model.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async Task<TokenViewModel> Refresh(RefreshTokenViewModel model)
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var token = await model.Refresh(context, configuration, accountId, HttpContext);

			await context.SaveChangesAsync();
			
			return token;
		}
	}
}