using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;

namespace TEKUtsav.Ral.Impl
{
	public class HttpHandler : DelegatingHandler
	{
		private string tableName;
		private string propertyName;
		private string sortOrder;
		private bool logRequestResponseBody;

		public HttpHandler(string tableName, string propertyName, string sortOrder)
		{
			this.tableName = tableName;
			this.propertyName = propertyName;
			this.sortOrder = sortOrder;
			this.logRequestResponseBody = false;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
		{
			request.Headers.Add("Authorization", HAccountUtil.GetHAccount());

			Debug.WriteLine("Request: {0} {1}", request.Method, request.RequestUri.ToString());

			if (logRequestResponseBody && request.Content != null)
			{
				var requestContent = await request.Content.ReadAsStringAsync();
				Debug.WriteLine(requestContent);
			}

			Debug.WriteLine("HEADERS");

			foreach (var header in request.Headers)
			{
				Debug.WriteLine(string.Format("{0}:{1}", header.Key, string.Join(",", header.Value)));
			}

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

			var response = await base.SendAsync(request, cancellationToken);

			Debug.WriteLine("Response: {0}", response.StatusCode);

			if (logRequestResponseBody)
			{
				var responseContent = await response.Content.ReadAsStringAsync();
				Debug.WriteLine(responseContent);
			}

			return response;
		}
	}
}
