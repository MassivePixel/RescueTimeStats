using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using console.test.Data;
using Newtonsoft.Json;

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

                var obj = JsonConvert.DeserializeObject<DefaultResponse>(result);
                var rows = new List<RowInfo>();
                foreach (var row in obj.rows)
                    rows.Add(new RowInfo(row));

                var times = rows.GroupBy(i => i.Productivity)
                    .ToDictionary(g => g.Key, g => TimeSpan.FromSeconds(g.Sum(i => i.TimeSpent)));
                var total = times.Sum(i => i.Value.TotalSeconds);
                foreach (var time in times)
                {
                    Console.WriteLine("{0} {1} {2:0.00}%", time.Key, time.Value, (float)time.Value.TotalSeconds / (float)total * 100);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
