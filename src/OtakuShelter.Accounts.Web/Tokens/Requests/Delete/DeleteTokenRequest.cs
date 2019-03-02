using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class DeleteTokenRequest
	{
		[DataMember(Name = "tokenId")]
		public int TokenId { get; set; }

		public async ValueTask  Delete(AccountsContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			var token = await context.Tokens.FirstAsync(t => t.Id == TokenId);
			
			if (token.Account != account)
				throw new UnauthorizedAccessException();

			context.Tokens.Remove(token);
		}
	}
}