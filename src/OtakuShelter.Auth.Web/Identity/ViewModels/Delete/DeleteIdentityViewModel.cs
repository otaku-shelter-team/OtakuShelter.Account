using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OtakuShelter.Auth
{
	public class DeleteIdentityViewModel
	{
		public async Task Delete(AuthContext context, int identityId)
		{
			var identity = await context.Identities.FirstAsync(i => i.Id == identityId);

			context.Identities.Remove(identity);
		}
	}
}