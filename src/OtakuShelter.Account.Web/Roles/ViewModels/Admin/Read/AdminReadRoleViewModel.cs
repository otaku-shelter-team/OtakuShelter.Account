using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminReadRoleViewModel
	{
		[DataMember(Name = "roles")]
		public ICollection<AdminReadRoleItemViewModel> Roles { get; private set; }
		
		public async Task Load(AccountContext context, int offset, int limit)
		{
			Roles = await context.Roles
				.Skip(offset)
				.Take(limit)
				.Select(role => new AdminReadRoleItemViewModel(role))
				.ToListAsync();
		}
	}
}