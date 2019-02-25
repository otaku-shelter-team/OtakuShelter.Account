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

		public async ValueTask<TokenRequest> Create(CreateTokenRequest request)
		{
			var token = await request.Create(context, hasher, configuration, HttpContext);

			await context.SaveChangesAsync();

			return token;
		}

		public async ValueTask<ReadTokenResponse> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var response = new ReadTokenResponse();

			await response.Load(context, accountId);

			return response;
		}
		
		public async ValueTask<TokenRequest> Refresh(RefreshTokenRequest request)
		{
			var token = await request.Refresh(context, configuration, HttpContext);

			await context.SaveChangesAsync();
			
			return token;
		}

		public async ValueTask  Delete(DeleteTokenRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Delete(context, accountId);

			await context.SaveChangesAsync();
		}
		
		public async ValueTask<AdminReadByIdTokenResponse> AdminReadById(int accountId)
		{
			var response = new AdminReadByIdTokenResponse();

			await response.Load(context, accountId);

			return response;
		}
		
		public async ValueTask  AdminDeleteById(AdminDeleteByIdTokenRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}