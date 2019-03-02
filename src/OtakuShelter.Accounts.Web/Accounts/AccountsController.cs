using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OtakuShelter.Accounts
{
	public class AccountsController : ControllerBase
	{
		private readonly AccountsContext context;
		private readonly AccountsRoleConfiguration roles;
		private readonly IPasswordHasher<Account> hasher;

		public AccountsController(
			AccountsContext context,
			IPasswordHasher<Account> hasher,
			IOptions<AccountsRoleConfiguration> roles)
		{
			this.context = context;
			this.roles = roles.Value;
			this.hasher = hasher;
		}

		public async ValueTask  Create(CreateAccountRequest request)
		{
			await request.Create(context, hasher, roles);

			await context.SaveChangesAsync();
		}

		public async ValueTask<ReadAccountResponse> Read()
		{
			var accountId = int.Parse(User.Identity.Name);
			
			var response = new ReadAccountResponse();

			await response.Read(context, accountId);

			return response;
		}

		public async ValueTask  Update(UpdateAccountRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Update(context, hasher, accountId);

			await context.SaveChangesAsync();
		}
		
		public async ValueTask  Delete(DeleteAccountRequest request)
		{
			var accountId = int.Parse(User.Identity.Name);

			await request.Delete(context, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask<AdminReadAccountResponse> AdminRead(FilterRequest filter)
		{
			var response = new AdminReadAccountResponse();

			await response.Read(context, filter.Offset, filter.Limit);

			return response;
		}

		public async ValueTask<AdminReadByIdAccountResponse> AdminReadById(int accountId)
		{
			var response = new AdminReadByIdAccountResponse();

			await response.Read(context, accountId);

			return response;
		}
		
		public async ValueTask  AdminUpdateById(int accountId, AdminUpdateByIdAccountRequest request)
		{
			await request.Update(context, hasher, roles, accountId);

			await context.SaveChangesAsync();
		}

		public async ValueTask  AdminDeleteById(AdminDeleteByIdAccountRequest request)
		{
			await request.Delete(context);

			await context.SaveChangesAsync();
		}
	}
}