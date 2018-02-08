using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;

namespace TEKUtsav.Ral.CloutUtils.Impl
{
	class ExpandPropertyHandler : DelegatingHandler
	{
		string tableName;
		string propertyName;
		string sortOrder;

		public ExpandPropertyHandler(string tableName, string propertyName, string sortOrder)
		{
			this.tableName = tableName;
			this.propertyName = propertyName;
			this.sortOrder = sortOrder;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			if (request.Method.Method == HttpMethod.Get.Method &&
				request.RequestUri.PathAndQuery.StartsWith("/tables/" + tableName, StringComparison.OrdinalIgnoreCase))
			{
				UriBuilder builder = new UriBuilder(request.RequestUri);
				string query = builder.Query;
				if (!query.Contains("$expand"))
				{
					if (string.IsNullOrEmpty(query))
					{
						query = "";
					}
					else
					{
						query = query + "&";
					}

					query = query + "$expand=" + propertyName + ((sortOrder != string.Empty ? "&$orderby=" + sortOrder : string.Empty));
					builder.Query = query.TrimStart('?');
					request.RequestUri = builder.Uri;
				}
			}

			return await base.SendAsync(request, cancellationToken);
			//return result;
		}
	 }
}
