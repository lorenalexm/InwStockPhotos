using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class Error
	{
		[JsonPropertyName("status")]
		public long Status { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("message")]
		public string? Message { get; set; }

		[JsonPropertyName("details")]
		public Details? Details { get; set; }
	}
}

