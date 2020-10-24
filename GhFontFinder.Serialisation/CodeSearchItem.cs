using System.Text.Json.Serialization;

namespace GhFontFinder.Serialisation
{
	public class CodeSearchItem
	{
		[JsonPropertyName("name")]       public string     Name       { get; set; }
		[JsonPropertyName("path")]       public string     Path       { get; set; }
		[JsonPropertyName("sha")]        public string     Sha        { get; set; }
		[JsonPropertyName("url")]        public string     Url        { get; set; }
		[JsonPropertyName("git_url")]    public string     GitUrl     { get; set; }
		[JsonPropertyName("html_url")]   public string     HtmlUrl    { get; set; }
		[JsonPropertyName("repository")] public Repository Repository { get; set; }
		[JsonPropertyName("score")]      public int        Score      { get; set; }
	}
}