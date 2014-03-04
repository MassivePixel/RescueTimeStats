using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MassivePixel.RescueTime.Common.Data
{
    public static class FetchService
    {
        public static async Task<Summary> GetSummaryAsync()
        {
            var client = new HttpClient();
            var uri = string.Format("https://www.rescuetime.com/anapi/data?key={0}&format=json", ApiConfig.ApiKey);
            try
            {
                var result = await client.GetStringAsync(uri);

                var response = await Task.Factory.StartNew(() =>
                {
                    return JsonConvert.DeserializeObject<DefaultResponse>(result);
                });

                var rows = new List<RowInfo>();
                foreach (var row in response.rows)
                    rows.Add(new RowInfo(row));

                var summary = new Summary
                {
                    OriginalResponse = response,
                    Data = rows
                };

                summary.Calculate();

                return summary;
            }
            catch (Exception ex)
            {
                ex.Report();
            }

            return null;
        }
    }
}
