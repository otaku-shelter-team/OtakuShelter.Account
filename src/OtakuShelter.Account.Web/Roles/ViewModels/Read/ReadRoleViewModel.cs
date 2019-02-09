using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadRoleViewModel
	{
		[DataMember(Name = "roles")]
		public ICollection<ReadRoleItemViewModel> Roles { get; private set; }
		
		public async Task Load(AccountContext context, int offset, int limit)
		{
			Roles = await context.Roles
				.Skip(offset)
				.Take(limit)
				.Select(role => new ReadRoleItemViewModel(role))
				.ToListAsync();
		}
	}
}