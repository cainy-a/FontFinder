using System.Text.Json.Serialization;

namespace GhFontFinder.Serialisation
{
	public class Repository
	{
		[JsonPropertyName("id")]          public int    Id          { get; set; }
		[JsonPropertyName("node_id")]     public string NodeId      { get; set; }
		[JsonPropertyName("full_name")]   public string FullName    { get; set; }
		[JsonPropertyName("private")]     public bool   Private     { get; set; }
		[JsonPropertyName("owner")]       public User   Owner       { get; set; }
		[JsonPropertyName("html_url")]    public string HtmlUrl     { get; set; }
		[JsonPropertyName("description")] public string Description { get; set; }
		[JsonPropertyName("fork")]        public bool   Fork        { get; set; }
		[JsonPropertyName("url")]         public string Url         { get; set; }
		[JsonPropertyName("forks_url")]   public string ForksUrl    { get; set; }
		[JsonPropertyName("keys_url")]    public string KeysUrl     { get; set; }

		[JsonPropertyName("collaborators_url")]
		public string CollaboratorsUrl { get; set; }
	}
}