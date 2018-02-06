using System;
using System.Threading.Tasks;
using TEKUtsav.CloudUtils.Ral;
using TEKUtsav.Models.Entities;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;

namespace TEKUtsav.Ral.CloudUtils
{
	public interface ICloudService
	{
		ICloudTable<T> GetTable<T>(MobileServiceClient client) where T : TableData;
		Task<T> InvokeApiAsyncPost<T,I>(MobileServiceClient client, string url, T item);
		Task<T> InvokeApiAsyncGet<T>(MobileServiceClient client, string url);
        Task<I> InvokeApiAsyncPostData<T, I>(MobileServiceClient client, string url, T item);
	}
}
