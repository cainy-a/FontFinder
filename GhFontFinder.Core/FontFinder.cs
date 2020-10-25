using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using GhFontFinder.Serialisation;

namespace GhFontFinder.Core
{
	public class FontFinder
	{
		private string _username = "cainy-a";
		private string _token = "7ba0cf756f6e71b67d789c29dc4f5f98a80e7ad4";

		private SearchResult SearchAllCode(string query)
		{
			var encodedQuery = HttpUtility.UrlEncode(query); // encode query
			var url = $"https://api.github.com/search/code?q={encodedQuery}"; // construct search URL

			var jsonText = ApiRequest(url);
			var deserialised = JsonSerializer.Deserialize<SearchResult>(jsonText); // Deserialise it
			return deserialised; // return it!!!
		}

		private string ApiRequest(string requestUrl)
		{
			using (var client = new HttpClient()) // create a HttpClient
			{
				// Add an OAuth2 token to allow searching code site-wide
				client.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Basic",
												  Convert
													 .ToBase64String(Encoding.ASCII.GetBytes($"{_username}:{_token}")));
				// Add a valid User Agent
				client.DefaultRequestHeaders.UserAgent.ParseAdd("cainy-a/FontFinder");
				using (var result = client.GetAsync(requestUrl).Result) // Get the result from the API
				{
					return result.Content.ReadAsStringAsync().Result; // Get the text from the HttpResonseMessage
				}
			}
		}

		public string[] SearchForFont(string name, bool ttf = true, bool otf = true, bool woff2 = false)
		{
			// construct query
			var sb = new StringBuilder($"{name} in:path");
			if (!(ttf || otf || woff2)) throw new ArgumentException("You must search for at least one font format!");
			if (ttf) sb.Append($" extension:ttf");
			if (otf) sb.Append($" extension:otf");
			if (woff2) sb.Append($" extension:woff2");
			var query = sb.ToString();
			
			// get result of query
			var result = SearchAllCode(query);
			var files = (from searchResult in result.Items
						 select ApiRequest(searchResult.Url) into fileApiResult
						 select JsonSerializer.Deserialize<File>(fileApiResult)).ToList();
			var friendlyDisplay = files.Select(f => $"{f.Name}: {f.DownloadUrl.AbsoluteUri}").ToArray();
			return friendlyDisplay;
		}
	}
}