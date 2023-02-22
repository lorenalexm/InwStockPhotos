using System;

namespace InwStockPhotos.Services
{
	public enum RequestMethod
	{
		Get,
		Post,
		Put,
		Delete
	}

	public interface IStrapiRequests
	{
		abstract public Task<T?> ExecuteAsync<T>(string endpoint, RequestMethod method, object? parameter = null, string populateRelations = "", bool randomize = false, string token = "");
		abstract public Task<IEnumerable<T?>> GetAllAsync<T>();
		abstract public Task<T?> GetAsync<T>(int id);
		abstract public Task<T?> UpdateAsync<T>(int id, object parameter);
	}
}

