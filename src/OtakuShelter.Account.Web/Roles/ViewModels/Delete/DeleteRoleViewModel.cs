using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class DeleteRoleViewModel
	{
		[DataMember(Name = "roleId")]
		public int RoleId { get; set; }
		
		public async Task Delete(AccountContext context)
		{
			var role = await context.Roles.FirstAsync(r => r.Id == RoleId);

			context.Roles.Remove(role);
		}
	}
}