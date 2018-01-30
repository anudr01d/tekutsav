using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TEKUtsav.CloudUtils.Ral;
using TEKUtsav.Models.Entities;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace TEKUtsav.Ral.CloudUtils.Impl
{
	public class CloudTable<T> : ICloudTable<T> where T : TableData
	{
		MobileServiceClient client;
		IMobileServiceTable<T> table;

		public CloudTable(MobileServiceClient client)
		{
            this.client = client;
            this.table = client.GetTable<T>();
		}

		#region ICloudTable implementation
		public async Task<T> CreateItemAsync(T item)
		{
			try
			{
				await table.InsertAsync(item);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.StackTrace);
			}
			return item;
		}

		public async Task DeleteItemAsync(T item)
		{
			await table.DeleteAsync(item);
		}

		public async Task<ICollection<T>> ReadAllItemsAsync()
		{
			ICollection<T> val = null;
			try
			{
				val = await table.ToListAsync();
			}
			catch (Exception e) {
				Debug.WriteLine(e.StackTrace);
			}
			return val;
		}

		public async Task<T> ReadItemAsync(string id)
		{
			T val = null;
			try
			{
				val = await table.LookupAsync(id);
			}
			catch (Exception e) { Debug.WriteLine(e.StackTrace); }
			return val;
		}

		public async Task<T> UpdateItemAsync(T item)
		{
			try
			{
				await table.UpdateAsync(item);
			}
			catch (Exception e) { 
				Debug.WriteLine(e.StackTrace); 
			}
			return item;
		}
		#endregion
	}
}
