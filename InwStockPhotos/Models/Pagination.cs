using System;
using System.Text.Json.Serialization;

namespace InwStockPhotos.Models
{
	public partial class Pagination
	{
		[JsonPropertyName("page")]
		public long Page { get; set; }

		[JsonPropertyName("pageSize")]
		public long PageSize { get; set; }

		[JsonPropertyName("pageCount")]
		public long PageCount { get; set; }

		[JsonPropertyName("total")]
		public long Total { get; set; }
	}
}

