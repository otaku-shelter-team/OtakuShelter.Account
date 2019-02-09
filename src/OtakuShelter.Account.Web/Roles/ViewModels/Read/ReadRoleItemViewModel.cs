using System.Runtime.Serialization;

namespace OtakuShelter.Account
{
	[DataContract]
	public class ReadRoleItemViewModel
	{
		public ReadRoleItemViewModel(Role role)
		{
			Id = role.Id;
			Name = role.Name;
		}
		
		[DataMember(Name = "id")]
		public int Id { get; set; }
		
		[DataMember(Name = "name")]
		public string Name { get; set; }
	}
}