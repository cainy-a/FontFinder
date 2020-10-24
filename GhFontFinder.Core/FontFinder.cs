using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GhFontFinder.Serialisation;

namespace GhFontFinder.Core
{
	public class FontFinder
	{
		private string _username = "cainy-a";
		private string _token = "7ba0cf756f6e71b67d789c29dc4f5f98a80e7ad4";

		public SearchResult DownloadJson()
		{
			var url = "https://api.github.com/search/code?q=hello%20world";
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Authorization 
					= new AuthenticationHeaderValue("Basic", 
													Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_token}")));
				client.DefaultRequestHeaders.UserAgent.ParseAdd("cainy-a/FontFinder");
				using (var result = client.GetAsync(url).Result)
				{
					var jsonText = result.Content.ReadAsStringAsync().Result;
					// TODO: serialise json
				}
			}
		}
	}
}