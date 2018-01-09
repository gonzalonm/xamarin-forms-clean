using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace XamarinCleanApp.Core.Data.Net
{
	public class ApiConnection
	{
		public const string HostUrl = "http://www.mocky.io/v2/5a53c3aa30000066351ec049";

		static HttpClient BuildClient()
		{
			var client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			return client;
		}

		public static async Task<string> DoGet(string endpoint)
		{
			var uri = new Uri(endpoint);
			var client = BuildClient();
			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				return content;
			}
			return "";
		}
	}
}
