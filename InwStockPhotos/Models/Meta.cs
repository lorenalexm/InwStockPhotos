using System;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class Meta
	{
		[JsonPropertyName("pagination")]
		public Pagination? Pagination { get; set; }
	}
}

