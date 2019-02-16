using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadByIdRoleViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task ReadById(AccountContext context, int roleId)
		{
			var role = await context.Roles.FirstAsync(r => r.Id == roleId);

			Name = role.Name;
		}
	}
}