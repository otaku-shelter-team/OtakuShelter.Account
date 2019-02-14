using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminReadByIdAccountViewModel
	{
		[DataMember(Name = "username")]
		public string Username { get; private set; }
		
		[DataMember(Name = "created")]
		public DateTime Created { get; private set; }
		
		[DataMember(Name = "roleId")]
		public int RoleId { get; private set; }
		
		public async Task Read(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			Username = account.Username;
			Created = account.Created;
			RoleId = account.Role.Id;
		}
	}
}