using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminCreateRoleViewModel
	{
		[DataMember(Name = "name")]
		public string Name { get; set; }
		
		public async Task Create(AccountContext context)
		{
			var role = new Role
			{
				Name = Name
			};

			await context.Roles.AddAsync(role);
		}
	}
}