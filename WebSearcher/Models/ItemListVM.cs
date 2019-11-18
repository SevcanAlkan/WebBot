using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearcher.Models
{
    public class ItemListVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string URL { get; set; }

        public override string ToString()
        {
            return $"Name= {Name} | Price= {Price} TL | URL: {URL}";
        }
    }
}
