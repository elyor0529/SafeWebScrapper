using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WheelsScraper;

namespace Jobboerse
{
    public class ExtWareInfo : WareInfo
    {
        public int? Page { get; set; }

        public string SearchKeyword { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Contact { get; set; }

        public string Url { get; set; }

    }
}
