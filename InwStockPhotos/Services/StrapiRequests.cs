﻿using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

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
					return JsonSerializer.Deserialize<T>(content);
				}
			}
			catch(Exception exception)
			{
				Console.WriteLine($"Failed to execute the request to Strapi!\nReceived an error of: {exception.ToString()}");
			}
			return default(T);
		}

		public async Task<IEnumerable<T?>> GetAllAsync<T>()
		{
			throw new NotImplementedException();
		}

		public async Task<T?> GetAsync<T>(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<T?> UpdateAsync<T>(int id, object parameter)
		{
			throw new NotImplementedException();
		}
	}
}
