using NUnit.Framework;
using RichardSzalay.MockHttp;
using InwStockPhotos.Services;
using InwStockPhotos.Models;

namespace InwStockPhotosTests
{
	public class StrapiRequestsTests
	{
		private IStrapiRequests? requests;
		private MockHttpMessageHandler mockHandler;
		private string _url = "https://inw-stock-photos-strapi.myside.app/";

		/// <summary>
		/// Creates a new <see cref="MockHttpMessageHandler"/> before each test.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			mockHandler = new MockHttpMessageHandler();
		}

		/// <summary>
		/// Disposes of the <see cref="MockHttpMessageHandler"/> after each test.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			mockHandler.Dispose();
		}

		/// <summary>
		/// Tests getting a single <see cref="ContentBlock"/> from a remote source.
		/// </summary>
		[Test]
		public async Task GetASingleContentBlock()
		{
			var endpoint = "api/content-blocks";
			mockHandler.When($"{_url}/{endpoint}/*")
				.Respond("application/json", SampleData.ContentBlock);
			var client = mockHandler.ToHttpClient();
			var requester = new StrapiRequests(client, _url);
			var content = await requester.GetAsync<ContentBlock>(1);

			Assert.That(content.Error, Is.Not.Null);
			Assert.That(content.Meta, Is.Not.Null);
			Assert.That(content.Data.Attributes.Title, Is.EqualTo("About us"));
		}
	}
}
