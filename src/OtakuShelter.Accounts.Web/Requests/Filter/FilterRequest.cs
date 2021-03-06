using System.Runtime.Serialization;

namespace OtakuShelter.Accounts
{
	[DataContract]
	public class FilterRequest
	{
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
		
		[DataMember(Name = "offset")]
		public int Limit { get; set; } = 10;
	}
}