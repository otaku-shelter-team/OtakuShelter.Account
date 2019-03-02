using Microsoft.Extensions.Options;

namespace OtakuShelter.Accounts
{
	public class VersionController
	{
		private readonly AccountsConfiguration configuration;

		public VersionController(IOptions<AccountsConfiguration> configuration)
		{
			this.configuration = configuration.Value;
		}
		
		public ReadVersionResponse Version()
		{
			var response = new ReadVersionResponse();

			response.Read(configuration);

			return response;
		}
	}
}