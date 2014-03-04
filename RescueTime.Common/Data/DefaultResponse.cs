using System.Collections.Generic;

namespace MassivePixel.RescueTime.Common.Data
{
    internal class DefaultResponse
    {
        public string notes { get; set; }
        public List<string> row_headers { get; set; }
        public List<List<object>> rows { get; set; }
    }
}
