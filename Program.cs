using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Maktabkhone
{
	class Program
	{
		static void Main()
		{
			Index("https://maktabkhooneh.org/course/35/lesson/", 20);
			Console.Read();
			

			//foreach (var item in ls)
			//{
			//	Index(item[0], 40, item[1], true);
			//}
		}

		public static void Rename(string oldfilename, string newfilename)
		{
			File.Move(oldfilename, newfilename);
		}

		public async static void Index(string url, int end,string title="", bool onlyNames = false)
		{
			List<string> urls = new List<string>();
			HttpClient hc = new HttpClient();
			HtmlDocument doc = new HtmlDocument();
			for (int i = 1; i < end; i++)
			{
				try
				{
					HttpResponseMessage result = await hc.GetAsync(url + i);
					Stream stream = await result.Content.ReadAsStreamAsync();
					doc.Load(stream);
					HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//a[@class=\"video-dl\"]");
					var address = links[0].Attributes["href"].Value.Replace(" ", "");
					if (onlyNames)
						address = address.Substring(address.IndexOf("videos/") + 7).Replace("?name=", ",");
					urls.Add(address);
				}
				catch
				{
					break;
				}
			}
			Console.WriteLine(title);
			Console.WriteLine(string.Join("\n", urls));
		}

		//# http://cdnmaktab.takhtesefid.org/videos/155767497011.mp4?name=tabesh-advancedad_1.mp4
		//static List<string[]> ls = new List<string[]>{
		//	//new[]{"https://maktabkhooneh.org/course/261/lesson/", "FAlgTeh"},
		//	new[]{"https://maktabkhooneh.org/course/229/lesson/", "AI"},
		//	new[]{"https://maktabkhooneh.org/course/218/lesson/", "BigDataAlg"},
		//	new[]{"https://maktabkhooneh.org/course/179/lesson/", "PatternRec"},
		//	new[]{"https://maktabkhooneh.org/course/231/lesson/", "Algo"},
		//	new[]{"https://maktabkhooneh.org/course/273/lesson/", "ML"},
		//	new[]{"https://maktabkhooneh.org/course/189/lesson/", "AlgoTeh"}
		//};
	}
}
