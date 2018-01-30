using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace TEKUtsav.Ral
{
	public interface IAzureClient
	{
		MobileServiceClient GetClient(string tableName, string propertyName, string sortOrder);
	}
}
