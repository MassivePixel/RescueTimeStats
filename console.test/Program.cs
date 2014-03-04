using System;
using System.Net.Http;

namespace console.test
{
    class Program
    {
        static void Main()
        {
            var client = new HttpClient();
            var uri = string.Format("https://www.rescuetime.com/anapi/data?key={0}&format=json", ApiConfig.ApiKey);
            try
            {
                var result = client.GetStringAsync(uri).Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
