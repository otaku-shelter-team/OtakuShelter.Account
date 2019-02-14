using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadTokenViewModel
	{
		[DataMember(Name = "tokens")]
		public ICollection<ReadTokenItemViewModel> Tokens { get; private set; }
		
		public async Task Load(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			Tokens = account.Tokens
				.Select(t => new ReadTokenItemViewModel(t))
				.ToList();
		}
	}
}