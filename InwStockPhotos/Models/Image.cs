using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class Image
	{
		public static readonly string Endpoint = "api/images";

		[JsonPropertyName("data")]
		public List<ImageData>? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class Images
	{
		public static readonly string Endpoint = "api/images";

		[JsonPropertyName("data")]
		public List<Image>? Data { get; set; }

		[JsonPropertyName("meta")]
		public Meta? Meta { get; set; }

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}

	public partial class ImageData
	{
		[JsonPropertyName("id")]
		public long Id { get; set; }

		[JsonPropertyName("attributes")]
		public ImageAttributes? Attributes { get; set; }
	}

	public partial class ImageAttributes
	{
		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("createdAt")]
		public DateTimeOffset CreatedAt { get; set; }

		[JsonPropertyName("updatedAt")]
		public DateTimeOffset UpdatedAt { get; set; }

		[JsonPropertyName("publishedAt")]
		public DateTimeOffset PublishedAt { get; set; }

		[JsonPropertyName("tags")]
		public Tags? Tags { get; set; }
	}
}
