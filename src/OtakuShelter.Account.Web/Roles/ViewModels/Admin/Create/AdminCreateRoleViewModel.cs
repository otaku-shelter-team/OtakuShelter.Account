using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminCreateRoleViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(AccountContext context, int accountId)
		{
			var creator = await context.Accounts.FirstAsync(a => a.Id == accountId);
			
			var role = new Role
			{
				Name = Name,
				Created = DateTime.UtcNow,
				Creator = creator
			};

			await context.Roles.AddAsync(role);
		}
	}
}