using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	public class DeleteAccountRequest
	{
		public async ValueTask  Delete(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(i => i.Id == accountId);

			context.Accounts.Remove(account);
			context.Tokens.RemoveRange(account.Tokens);
		}
	}
}