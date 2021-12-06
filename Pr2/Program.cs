using System;
using System.Net;

namespace Pr2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес сайта: ");
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument html = web.Load(Console.ReadLine(), "GET");

            int counter = 0;
            string[] values = new string[5];

            foreach (HtmlAgilityPack.HtmlNode node in html.DocumentNode.SelectNodes("//img"))
            {
                if (counter > 4)
                {
                    break;
                }

                if (node.Attributes["src"] != null)
                {
                    Console.WriteLine(node.Attributes["src"].Value);
                    values[counter] = node.Attributes["src"].Value;
                }
                counter++;
            }

            counter = 0;
            foreach (string url in values)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, $"C:\\Users\\Мария\\Pictures\\{counter}.png");
                }
                counter++;
            }
        }
    }
}
