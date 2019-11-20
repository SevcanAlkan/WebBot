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

        DbSet<SearchPoint> searchPoints { get; set; }
    }
}
