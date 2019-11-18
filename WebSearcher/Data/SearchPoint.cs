using System;
using System.Collections.Generic;
using System.Text;

namespace WebSearcher.Data
{
    public class SearchPoint
    {
        public Guid Id { get; set; }
        public Guid WebSiteId { get; set; }
        public DateTime? CheckDate { get; set; }
        public string UrlParameters { get; set; }
        public double Price { get; set; }
    }
}
