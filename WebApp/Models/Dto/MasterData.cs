using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.Dto
{
    public class MasterData
    {
        public class Country
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public class Currency
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }
    }
}
