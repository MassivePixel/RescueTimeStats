using System.Collections.Generic;

namespace console.test.Data
{
    class DefaultResponse
    {
        public string notes { get; set; }
        public List<string> row_headers { get; set; }
        public List<List<object>> rows { get; set; }
    }
}
