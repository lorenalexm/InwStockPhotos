using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class Tag
	{
		public static string Endpoint = "api/tags";

		[JsonPropertyName("data")]
		public List<TagData>? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class Tags
	{
		public static readonly string Endpoint = "api/tags";

		[JsonPropertyName("data")]
		public List<Tag>? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class TagData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("attributes")]
		public TagAttributes? Attributes { get; set; }
	}

	public partial class TagAttributes
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("createdAt")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonPropertyName("updatedAt")]
		public DateTimeOffset UpdatedAt { get; set; }
	}
}
