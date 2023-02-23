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
		private string _url = "https://apptesting.mock";

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
		public async Task Succeed_GettingASingleContentBlock()
		{
			var endpoint = "api/content-blocks";
			mockHandler.When($"{_url}/{endpoint}/*")
				.Respond("application/json", SampleData.ContentBlock);
			var client = mockHandler.ToHttpClient();
			var requester = new StrapiRequests(client, _url);
			var content = await requester.GetAsync<ContentBlock>(1);

			Assert.That(content, Is.Not.Null, "Content should not be null");
			Assert.That(content.Error, Is.Null, "Error should be null");
			Assert.That(content.Data.Attributes.Title, Is.EqualTo("About us"), "Title should be 'About us'");
		}

		/// <summary>
		/// Tests getting a single <see cref="ContentBlock"/> from a remote source.
		/// </summary>
		[Test]
		public async Task Fail_GettingASingleContentBlock()
		{
			var endpoint = "api/content-blocks";
			mockHandler.When($"{_url}/{endpoint}/*")
				.Respond("application/json", SampleData.Error404);
			var client = mockHandler.ToHttpClient();
			var requester = new StrapiRequests(client, _url);
			var content = await requester.GetAsync<ContentBlock>(1);

			Assert.That(content.Data, Is.Null, "Content should be null");
			Assert.That(content.Error, Is.Not.Null, "Error should not be null");
			Assert.That(content.Error.Status, Is.EqualTo(404), "Status should be '404'");
		}

		/// <summary>
		/// Tests getting multiple <see cref="ContentBlocks"/> from a remote source.
		/// </summary>
		[Test]
		public async Task Succeed_GettingMultipleContentBlocks()
		{
			var endpoint = "api/content-blocks";
			mockHandler.When($"{_url}/{endpoint}")
				.Respond("application/json", SampleData.ContentBlocks);
			var client = mockHandler.ToHttpClient();
			var requester = new StrapiRequests(client, _url);
			var content = await requester.GetAllAsync<ContentBlocks>();

			Assert.That(content, Is.Not.Null, "Content should not be null");
			Assert.That(content.Error, Is.Null, "Error should be null");
			Assert.That(content.Meta.Pagination.Total, Is.EqualTo(3), "Pagination should be equal to 3");
			Assert.That(content.Data[1].Attributes.Title, Is.EqualTo("Subscribe now"), "Title of second in list should be 'Subscribe now'");
		}
	}
}
