using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadAccountViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; set; }
		
		public async Task Read(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(i => i.Id == accountId);

			Username = account.Username;
		}
	}
}