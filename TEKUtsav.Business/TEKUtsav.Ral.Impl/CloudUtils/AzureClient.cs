using System;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Constants;
using Microsoft.WindowsAzure.MobileServices;

namespace TEKUtsav.Ral.Impl
{
	public class AzureClient : IAzureClient
	{
		public AzureClient()
		{
		}

		public MobileServiceClient GetClient(string tableName, string propertyName, string sortOrder)
		{
			return new MobileServiceClient(Globals.AZURE_URL, new HttpHandler(tableName, propertyName, sortOrder));
		}
	}
}
