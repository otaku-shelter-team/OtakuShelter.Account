using System.Runtime.Serialization;

namespace OtakuShelter.Account
{
	[DataContract]
	public class FilterViewModel
	{
		[DataMember(Name = "offset")]
		public int Offset { get; set; }
		
		[DataMember(Name = "offset")]
		public int Limit { get; set; } = 10;
	}
}