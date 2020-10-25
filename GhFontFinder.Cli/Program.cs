using System;
using GhFontFinder.Core;

namespace GhFontFinder.Cli
{
	class Program
	{
		static void Main(string[] args)
		{
			var finder = new FontFinder();
			
			Console.Write("Search for Truetype (*.TTF) fonts? [y/n]");
			var ttf = "y" == Console.ReadLine().ToLower();
			
			Console.Write("Search for Opentype (*.OTF) fonts? [y/n]");
			var otf = "y" == Console.ReadLine().ToLower();
			
			Console.Write("Search for Woff2 (*.WOFF2) webfonts? [y/n]");
			var woff2 = "y" == Console.ReadLine().ToLower();
			
			Console.Write("What font would you like to get?");
			var fontName = Console.ReadLine();
			
			Console.WriteLine("Getting results from Github, please wait...");
			
			var results = finder.SearchForFont(fontName, ttf, otf, woff2);
			
			foreach (var result in results) Console.WriteLine(result);
		}
	}
}