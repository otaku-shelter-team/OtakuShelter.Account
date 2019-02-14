using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Account
{
	[DataContract]
	public class AdminDeleteByIdTokenViewModel
	{
		[DataMember(Name = "tokenId")]
		public int TokenId { get; set; }

		public async Task Delete(AccountContext context)
		{
			var token = await context.Tokens.FirstAsync(t => t.Id == TokenId);
			
			context.Tokens.Remove(token);
		}
	}
}