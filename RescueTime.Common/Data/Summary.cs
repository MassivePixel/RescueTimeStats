using System;
using System.Collections.Generic;
using System.Linq;

namespace MassivePixel.RescueTime.Common.Data
{
    public class Summary
    {
        internal DefaultResponse OriginalResponse { get; set; }
        public List<RowInfo> Data { get; set; }

        public void Calculate()
        {
            Times = Data.GroupBy(i => i.Productivity)
                .ToDictionary(g => g.Key, g => TimeSpan.FromSeconds(g.Sum(i => i.TimeSpent)));

            Total = Times.Sum(i => i.Value.TotalSeconds);
        }

        public Dictionary<int, TimeSpan> Times { get; set; }

        public double Total { get; set; }
    }
}