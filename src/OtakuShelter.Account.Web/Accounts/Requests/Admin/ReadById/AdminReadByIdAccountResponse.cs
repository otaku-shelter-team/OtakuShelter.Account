using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminReadByIdAccountResponse
	{
		[DataMember(Name = "username")]
		public string Username { get; private set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; private set; }
		
		[DataMember(Name = "role")]
		public string Role { get; private set; }
		
		public async ValueTask  Read(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			Username = account.Username;
			Created = account.Created;
			Role = account.Role;
		}
	}
}