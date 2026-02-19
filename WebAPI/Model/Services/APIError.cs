using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model.Services
{
    public class APIError
    {
        public string ErrorCode { get; set; } = default;
        public string Message { get; set; } = default;
        public List<string> Detail { get; set; } = new List<string>();
        public string TraceID { get; set; } = default;

    }
}
