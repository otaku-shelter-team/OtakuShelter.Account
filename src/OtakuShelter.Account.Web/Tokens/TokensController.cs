using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Account
{
	public class TokensController
	{
		private readonly AccountContext context;
		private readonly IPasswordHasher<Account> hasher;
		private readonly AuthWebConfiguration configuration;

		public TokensController(AccountContext context, IPasswordHasher<Account> hasher, IOptions<AuthWebConfiguration> configuration)
		{
			this.context = context;
			this.hasher = hasher;
			this.configuration = configuration.Value;
		}

		public async Task<TokenViewModel> Create(CreateTokenViewModel model)
		{
			var token = await model.Create(context, hasher, configuration);

			return new TokenViewModel(token);
		}
	}
}