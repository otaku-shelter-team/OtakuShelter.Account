using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class AdminDeleteByIdAccountRequest
	{
		[DataMember(Name = "accountId")]
		public int AccountId { get; set; }
		
		public async ValueTask  Delete(AccountsContext context)
		{
			var account = await context.Accounts
				.Include(a => a.Tokens)
				.FirstAsync(a => a.Id == AccountId);

			context.Accounts.Remove(account);
			context.Tokens.RemoveRange(account.Tokens);
		}
	}
}