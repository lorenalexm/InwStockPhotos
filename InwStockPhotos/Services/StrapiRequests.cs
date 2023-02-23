using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using InwStockPhotos.Models;

namespace InwStockPhotos.Services
{
	public class StrapiRequests: IStrapiRequests
	{
		public string ServerUrl { get; private set; }
		private readonly HttpClient _httpClient;

		/// <summary>
		/// Configures the <see cref="HttpClient"/> and sets the <see cref="ServerUrl"/>.
		/// </summary>
		/// <param name="serverUrl">The Url of the Strapi server.</param>
		public StrapiRequests(string serverUrl)
		{
			ServerUrl = serverUrl;

			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf8");
		}

		/// <summary>
		/// Configures the <see cref="HttpClient"/> and sets the <see cref="ServerUrl"/>. 
		/// </summary>
		/// <param name="client">A <see cref="HttpClient"/> to use instead of creating a new client.</param>
		/// <param name="serverUrl">The Url of the Strapi server.</param>
		public StrapiRequests(HttpClient client, string serverUrl)
		{
			ServerUrl = serverUrl;

			_httpClient = client;
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			_httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf8");
		}

		/// <summary>
		/// Performs a remote action on the <typeparamref name="T"/> model.
		/// </summary>
		/// <typeparam name="T">A model that matches a Strapi content type.</typeparam>
		/// <param name="endpoint">The endpoint of the Strapi content to work with.</param>
		/// <param name="method">Which type of request should be executed.</param>
		/// <param name="parameter">Optional. A model to serialize and send with <see cref="RequestMethod.Post"/> and <see cref="RequestMethod.Put"/> requests.</param>
		/// <param name="populateRelations">Optional. A comma seperated list of relations to populate.</param>
		/// <param name="randomize">Optional. Should <see cref="RequestMethod.Get"/> results be randomized?</param>
		/// <param name="token">Optional. An authorization token for the request.</param>
		/// <returns></returns>
		public async Task<T?> ExecuteAsync<T>(string endpoint, RequestMethod method, object? parameter = null, string populateRelations = "", bool randomize = false, string token = "")
		{
			try
			{
				HttpRequestMessage request;

				if (method == RequestMethod.Get)
				{
					request = new HttpRequestMessage(new HttpMethod(method.ToString()),
						$"{ServerUrl}/{endpoint}?populate={populateRelations}&randomSort={randomize.ToString()}");
				}
				else
				{
					request = new HttpRequestMessage(new HttpMethod(method.ToString()),
						$"{ServerUrl}/{endpoint}");
				}

				if(!string.IsNullOrEmpty(token))
				{
					request.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
				}

				if(method == RequestMethod.Post)
				{
					if(parameter != null)
					{
						request.Content = new StringContent(JsonSerializer.Serialize<T>((T)parameter));
					}
				}

				var response = await _httpClient.SendAsync(request);
				if(response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var options = new JsonSerializerOptions()
					{
						AllowTrailingCommas = true,
					};
					return JsonSerializer.Deserialize<T>(content, options);
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine($"Failed to execute the request to Strapi!\nReceived an error of: {exception.ToString()}");
			}
			return default(T);
		}

		/// <summary>
		/// Performs a <see cref="RequestMethod.Get"/> request and creates a <see cref="List{T}"/> of models from remote Strapi content.
		/// </summary>
		/// <typeparam name="T">A model that matches a Strapi content type.</typeparam>
		/// <returns>A list of objects of the <typeparamref name="T"/> type.</returns>
		public async Task<T?> GetAllAsync<T>()
		{
			string endpoint = "";
			var type = typeof(T).ToString();
			switch (type)
			{
				case "InwStockPhotos.Models.ContentBlocks":
					endpoint = ContentBlocks.Endpoint;
					break;

				case "InwStockPhotos.Models.Tags":
					endpoint = Tags.Endpoint;
					break;

				case "InwStockPhotos.Models.Images":
					endpoint = Images.Endpoint;
					break;
			}

			return await ExecuteAsync<T>($"{endpoint}", RequestMethod.Get);
		}

		/// <summary>
		/// Performs a <see cref="RequestMethod.Get"/> request and creates a model from remote Strapi content.
		/// </summary>
		/// <typeparam name="T">A model that matches a Strapi content type.</typeparam>
		/// <param name="id">The Strapi Id of the content to fetch.</param>
		/// <returns>A complete model object of the <typeparamref name="T"/> type.</returns>
		public async Task<T?> GetAsync<T>(int id)
		{
			string endpoint = "";
			var type = typeof(T).ToString();
			switch (type)
			{
				case "InwStockPhotos.Models.ContentBlock":
					endpoint = ContentBlock.Endpoint;
					break;

				case "InwStockPhotos.Models.Tag":
					endpoint = Tag.Endpoint;
					break;

				case "InwStockPhotos.Models.Image":
					endpoint = Image.Endpoint;
					break;
			}

			return await ExecuteAsync<T>($"{endpoint}/{id}", RequestMethod.Get);
		}

		public async Task<T?> UpdateAsync<T>(int id, object parameter)
		{
			throw new NotImplementedException();
		}
	}
}

