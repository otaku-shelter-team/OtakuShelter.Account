using System;
using System.Collections.Generic;

namespace OtakuShelter.Account
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public DateTime Created { get; set; }

		public int? CreatorId { get; set; }
		public virtual Account Creator { get; set; }
		
		public virtual ICollection<Account> Accounts { get; set; }
	}
}