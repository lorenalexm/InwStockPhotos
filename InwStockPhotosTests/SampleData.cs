namespace InwStockPhotosTests
{
	public static class SampleData
	{
		/// <summary>
		/// A JSON string for creating a single ContentBlock object.
		/// </summary>
		static public string ContentBlock = """
		{
		  "data": {
		    "id": 1,
		    "attributes": {
		      "title": "About us",
		      "body": ".",
		      "createdAt": "2023-02-14T23:24:58.955Z",
		      "updatedAt": "2023-02-14T23:31:03.428Z",
		      "publishedAt": "2023-02-14T23:31:03.375Z"
		    }
		  },
		  "meta": {},
		}
		""";

		/// <summary>
		/// A JSON string for creating three ContentBlock objects, with pagination data.
		/// </summary>
		static public string ContentBlocks = """
		{
		  "data": [
			{
			  "id": 1,
			  "attributes": {
				"title": "About us",
				"body": ".",
				"createdAt": "2023-02-14T23:24:58.955Z",
				"updatedAt": "2023-02-14T23:31:03.428Z",
				"publishedAt": "2023-02-14T23:31:03.375Z"
			  }
			},
		    {
		      "id": 2,
		      "attributes": {
		        "title": "Subscribe now",
		        "body": ".",
		        "createdAt": "2023-02-14T23:33:02.417Z",
		        "updatedAt": "2023-02-17T00:40:56.793Z",
		        "publishedAt": "2023-02-17T00:40:56.786Z"
		      }
		    },
		    {
		      "id": 3,
		      "attributes": {
		        "title": "Terms of service",
		        "body": ".",
		        "createdAt": "2023-02-14T23:51:00.290Z",
		        "updatedAt": "2023-02-17T00:41:03.051Z",
		        "publishedAt": "2023-02-17T00:41:03.037Z"
		      }
		    }
		  ],
		  "meta": {
		    "pagination": {
		      "page": 1,
		      "pageSize": 25,
		      "pageCount": 1,
		      "total": 3
		    }
		  }
		}
		""";

		/// <summary>
		/// A JSON string returning a 404 error message.
		/// </summary>
		static public string Error404 = """
		{
		  "data": null,
		  "error": {
		    "status": 404,
		    "name": "NotFoundError",
		    "message": "Not Found",
		    "details": {}
		  }
		}
		""";
	}
}

