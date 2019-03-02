using System.Runtime.Serialization;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class ReadVersionResponse
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		public void Read(AccountsConfiguration configuration)
		{
			Version = configuration.Version;
		}
	}
}