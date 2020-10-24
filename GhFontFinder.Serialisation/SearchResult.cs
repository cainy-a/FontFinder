using System.Text.Json.Serialization;

namespace GhFontFinder.Serialisation
{
	public class SearchResult
	{
		[JsonPropertyName("total_count")] public int TotalCount { get; set; }

		[JsonPropertyName("incomplete_results")]
		public bool Incomplete { get; set; }

		[JsonPropertyName("items")] public CodeSearchItem[] Items { get; set; }
	}
}