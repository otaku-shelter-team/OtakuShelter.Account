using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class AdminReadAccountResponse
	{
		[DataMember(Name = "accounts")]
		public ICollection<AdminReadAccountItemResponse> Accounts { get; private set; }
		
		public async ValueTask  Read(AccountsContext context, int offset, int limit)
		{
			Accounts = await context.Accounts
				.OrderByDescending(account => account.Created)
				.Skip(offset)
				.Take(limit)
				.Select(account => new AdminReadAccountItemResponse(account))
				.ToListAsync();
		}
	}
}