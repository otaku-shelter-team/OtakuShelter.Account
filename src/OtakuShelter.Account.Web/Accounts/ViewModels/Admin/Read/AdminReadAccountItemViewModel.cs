using System;
using System.Runtime.Serialization;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminReadAccountItemViewModel
	{
		public AdminReadAccountItemViewModel(Account account)
		{
			Id = account.Id;
			Username = account.Username;
			Created = account.Created;
			RoleId = account.RoleId;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "username")]
		public string Username { get; }

		[DataMember(Name = "created")]
		public DateTime Created { get; }

		[DataMember(Name = "roleId")]
		public int RoleId { get; }
	}
}