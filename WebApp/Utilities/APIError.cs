using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Utilities
{
    public class APIError
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string[] Detail { get; set; }
        public string traceID { get; set; }
    }
}
