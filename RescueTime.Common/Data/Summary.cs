using System;
using System.Collections.Generic;
using System.Linq;

namespace MassivePixel.RescueTime.Common.Data
{
    public class Summary
    {
        internal DefaultResponse OriginalResponse { get; set; }
        public List<RowInfo> Data { get; set; }

        public Dictionary<int, int> Times { get; private set; }

        public long Total { get; private set; }

        public double Productivity { get; private set; }

        public void Calculate()
        {
            Times = Data.GroupBy(i => i.Productivity)
                .ToDictionary(g => g.Key, g => g.Sum(i => i.TimeSpent));

            Total = Times.Sum(i => i.Value);
            Productivity = (double)Times.Where(i => i.Key > 0).Sum(i => i.Value) / Total * 100.0;
        }
    }
}