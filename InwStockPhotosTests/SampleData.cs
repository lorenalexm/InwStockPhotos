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
		      "body": "Welcome to INW Stock Photos, your go-to source for high-quality, locally sourced images to help you showcase your real estate listings. We understand that as a real estate agent, you need to stand out in a crowded market and make a lasting impression on potential buyers. That's why we've created a comprehensive collection of stunning images that will help you do just that.\n\nOur team of skilled photographers are experts in capturing the essence of each neighborhood and community. Whether you're looking for shots of local landmarks, breathtaking natural scenery, or unique cultural hotspots, we've got you covered. With our extensive library of images, you'll be able to create an engaging and visually appealing listing that will set you apart from the competition.\n\nAt INW Stock Photos, we take pride in delivering top-notch customer service and support. We understand that every agent has different needs, so we offer flexible licensing options and custom photo shoots to ensure that you get exactly what you need. Our goal is to make it as easy as possible for you to access and use our images, so that you can focus on what you do best - **selling real estate**.\n\nThank you for considering INW Stock Photos as your partner in real estate marketing. We're confident that our images will help you take your listings to the next level.",
		      "createdAt": "2023-02-14T23:24:58.955Z",
		      "updatedAt": "2023-02-14T23:31:03.428Z",
		      "publishedAt": "2023-02-14T23:31:03.375Z"
		    }
		  },
		  "meta": {},
		}
		""";

		/// <summary>
		/// A JSON string returning a 404 error message.
		/// </summary>
		static public string Error404Block = """
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

