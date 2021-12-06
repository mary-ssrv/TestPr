using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Pr3
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCityForecast();
        }

        /// <summary>
        /// Получение данных о погоде для запрашиваемого города
        /// </summary>
        public static void GetCityForecast()
        {
            Console.Write("Введите город: ");
            string city = Console.ReadLine();

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=d3aa27ec3cbd3a16b973a3b4583ab8b9";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            Console.WriteLine($"Сейчас в {city} " +
                $"{weatherResponse.Main.Temp} градусов, " +
                $"влажность:{weatherResponse.Main.Humidity} " +
                $" закат: {ConvertFromUnixTimestamp(weatherResponse.Sys.Sunset)}" +
                $" рассвет: {ConvertFromUnixTimestamp(weatherResponse.Sys.Sunrise)} ");

            try
            {
                using (StreamWriter sw = new StreamWriter($@"C:\Users\Мария\source\repos\TestPr\{DateTime.Now.ToString("dd/MM/yyyy")}.txt", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine($"Сейчас в {city} " +
                $"{weatherResponse.Main.Temp} градусов, " +
                $"влажность:{weatherResponse.Main.Humidity} " +
                $" закат: {ConvertFromUnixTimestamp(weatherResponse.Sys.Sunset)}" +
                $" рассвет: {ConvertFromUnixTimestamp(weatherResponse.Sys.Sunrise)} ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Время unix в UTC+3
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp + 10800);
        }
    }
}
