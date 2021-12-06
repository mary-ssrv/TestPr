using System;
using System.IO;

namespace TestPr
{
    class Pr1
    {
        static void Main(string[] args)
        {
            WriteAndSaveHref();
        }
        /// <summary>
        /// Сохраняет html-страницу и выводит значения атрибута HREF первых 20 тегов A
        /// </summary>
        public static void WriteAndSaveHref()
        {
            Console.Write("Введите адрес сайта: ");
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument html = web.Load(Console.ReadLine(), "GET");

            int counter = 0;
            string[] values = new string[20];

            foreach (HtmlAgilityPack.HtmlNode node in html.DocumentNode.SelectNodes("//a"))
            {
                if (counter > 19)
                {
                    break;
                }

                if (node.Attributes["href"] != null)
                {
                    Console.WriteLine(node.Attributes["href"].Value);
                    values[counter] = node.Attributes["href"].Value;
                }
                counter++;
            }

            try
            {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Мария\source\repos\TestPr\data.txt", false, System.Text.Encoding.Default))
                {
                    foreach (string a in values)
                    {
                        sw.WriteLine(a);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
