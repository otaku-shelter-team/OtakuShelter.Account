using System;
using System.Collections;
using System.Collections.Generic;

namespace OtakuShelter.Account
{
	public class Account
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string PasswordHash { get; set; }

		public DateTime Created { get; set; }
		
		public int RoleId { get; set; }
		public virtual Role Role { get; set; }
		
		public virtual ICollection<Token> Tokens { get; set; }
		public virtual ICollection<Role> Roles { get; set; }
	}
}