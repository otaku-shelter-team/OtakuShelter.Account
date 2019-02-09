using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadAccountViewModel
	{
		[DataMember(Name = "accounts")]
		public ICollection<ReadAccountItemViewModel> Accounts { get; set; }
		
		public async Task Load(AccountContext context, int offset, int limit)
		{
			Accounts = await context.Accounts
				.Skip(offset)
				.Take(limit)
				.Select(account => new ReadAccountItemViewModel(account))
				.ToListAsync();
		}
	}

	[DataContract]
	public class ReadAccountItemViewModel
	{
		public ReadAccountItemViewModel(Account account)
		{
			Id = account.Id;
			Username = account.Username;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "username")]
		public string Username { get; }
	}
}