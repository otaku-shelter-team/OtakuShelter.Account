using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	public class ReadTokenViewModel
	{
		public ICollection<ReadTokenItemViewModel> Tokens { get; private set; }
		
		public async Task Load(AccountContext context, int accountId)
		{
			var account = await context.Accounts.FirstAsync(a => a.Id == accountId);

			Tokens = account.Tokens
				.Select(t => new ReadTokenItemViewModel(t))
				.ToList();
		}
	}

	[DataContract]
	public class ReadTokenItemViewModel
	{
		public ReadTokenItemViewModel(Token token)
		{
			Id = token.Id;
			IpAddress = token.IpAddress;
			DateTime = token.DateTime;
			UserAgent = token.UserAgent;
		}

		[DataMember(Name = "id")]
		public int Id { get; }
		
		[DataMember(Name = "ipAddress")]
		public string IpAddress { get; }
		
		[DataMember(Name = "userAgent")]
		public string UserAgent { get; set; }
		
		[DataMember(Name = "dateTime")]
		public DateTime DateTime { get; }
	}
	
}