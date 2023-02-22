using System;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class ContentBlock
	{
		[JsonPropertyName("data")]
		public ContentBlockData? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class ContentBlocks
	{
		[JsonPropertyName("data")]
		public List<ContentBlock>? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class ContentBlockData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("attributes")]
		public ContentBlockAttributes? Attributes { get; set; }
	}

	public partial class ContentBlockAttributes
	{
		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("body")]
		public string? Body { get; set; }

		[JsonPropertyName("createdAt")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonPropertyName("updatedAt")]
		public DateTimeOffset UpdatedAt { get; set; }

		[JsonPropertyName("publishedAt")]
		public DateTimeOffset PublishedAt { get; set; }
	}
}

