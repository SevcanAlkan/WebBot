using System;
using System.Collections.Generic;
using System.Text;

namespace WebSearcher.Data
{
    public class WebSite
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}
