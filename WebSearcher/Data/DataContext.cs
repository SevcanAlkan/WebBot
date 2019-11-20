using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSearcher.Data;

namespace WebSearcher.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("webBotData")
        {

        }

        public DbSet<SearchPoint> searchPoints { get; set; }

        public bool IsSearchPointExist(string url)
        {
            if (url == String.Empty)
                return false;

            url = url.Trim();

            if (url.Substring(0, 1) != "/")
            {
                url = "/" + url;
            }

            return this.searchPoints.Any(a => a.UrlParameters == url);
        }
    }
}
