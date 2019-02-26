using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadTokenResponse
	{
		[DataMember(Name = "tokens")]
		public ICollection<ReadTokenItemResponse> Tokens { get; private set; }
		
		public async ValueTask  Load(AccountContext context, int accountId)
		{
			var account = await context.Accounts
				.Include(a => a.Tokens)
				.FirstAsync(a => a.Id == accountId);

			Tokens = account.Tokens
				.Select(t => new ReadTokenItemResponse(t))
				.ToList();
		}
	}
}