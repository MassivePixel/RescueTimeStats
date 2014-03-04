using System;
using System.Collections.Generic;
using System.Linq;

namespace console.test.Data
{
    public class RowInfo
    {
        public int Rank { get; private set; }
        public int TimeSpent { get; private set; }
        public int NumberOfPeople { get; private set; }
        public string Activity { get; private set; }
        public string Category { get; private set; }
        public int Productivity { get; private set; }

        public RowInfo(IReadOnlyList<object> data)
        {
            if (data == null)
                throw new NullReferenceException();

            if (data.Count != 6)
                throw new ArgumentException("Invalid input, must have 6 elements", "data");

            if (data.Any(i => i == null))
                throw new ArgumentException("Invalid input, must not contain null elements", "data");

            int rank;
            if (int.TryParse(data[0].ToString(), out rank))
                Rank = rank;

            int timespent;
            if (int.TryParse(data[1].ToString(), out timespent))
                TimeSpent = timespent;

            int noPeople;
            if (int.TryParse(data[2].ToString(), out noPeople))
                NumberOfPeople = noPeople;

            Activity = data[3].ToString();
            Category = data[4].ToString();

            int productivity;
            if (int.TryParse(data[5].ToString(), out productivity))
                Productivity = productivity;
        }
    }
}
