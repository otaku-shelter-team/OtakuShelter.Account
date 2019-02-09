using System.Collections.Generic;

namespace OtakuShelter.Account
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Account> Accounts { get; set; }
	}
}