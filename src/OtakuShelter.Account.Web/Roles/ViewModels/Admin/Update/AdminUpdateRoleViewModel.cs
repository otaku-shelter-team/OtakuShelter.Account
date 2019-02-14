using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminUpdateRoleViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Update(AccountContext context, int roleId)
		{
			var role = await context.Roles.FirstAsync(r => r.Id == roleId);

			if (Name != null)
			{
				role.Name = Name;
			}
		}
	}
}