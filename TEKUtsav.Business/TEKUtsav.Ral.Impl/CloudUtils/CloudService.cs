using System;
using TEKUtsav.CloudUtils.Ral;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Models.Entities;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.Impl;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TEKUtsav.Ral.CloudUtils.Impl
{
	public class CloudService : ICloudService
	{
		public CloudService()
		{
		}

		public ICloudTable<T> GetTable<T>(MobileServiceClient mClient) where T : TableData
		{
			return new CloudTable<T>(mClient);
		}

		public async Task<T> InvokeApiAsyncPost<T, I>(MobileServiceClient client, string url, T item)
		{
			T val = default(T);
			try
			{
				val = await client.InvokeApiAsync<T, T>(url, item, System.Net.Http.HttpMethod.Post, null);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
			return val;
		}

		public async Task<T> InvokeApiAsyncGet<T>(MobileServiceClient client, string url)
		{
			T val = default(T);
			try
			{
				val = await client.InvokeApiAsync<T>(url, HttpMethod.Get, null);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
			return val;
		}

        public async Task<I> InvokeApiAsyncPostData<T, I>(MobileServiceClient client, string url, T item)
        {
            I val = default(I);
            try
            {
                val = await client.InvokeApiAsync<T, I>(url, item, System.Net.Http.HttpMethod.Post, null);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }
            return val;
        }
       
	}
}
