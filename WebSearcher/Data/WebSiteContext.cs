using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSearcher.Data
{
    public static class WebSiteContext
    {
        public static Collection<WebSiteModel> Sites { get; private set; }

        public static void Load()
        {
            Sites = new Collection<WebSiteModel>();
            Sites.Add(new WebSiteModel() { Id = 1, Name = "Hepsiburada", URL = "https://www.hepsiburada.com", CurrencyCode = "TL" });
            Sites.Add(new WebSiteModel() { Id = 2, Name = "N11", URL = "https://www.n11.com", CurrencyCode = "TL" });
        }

        public static WebSiteModel GetModel(int id)
        {
            return Sites.Where(a => a.Id == id).FirstOrDefault();
        }

        public static string GetName(int id)
        {
            return Sites.Where(a => a.Id == id).Select(s => s.Name).FirstOrDefault();
        }

        public static string GetURL(int id)
        {
            return Sites.Where(a => a.Id == id).Select(s => s.URL).FirstOrDefault();
        }

        public static string GetCurrencyCode(int id)
        {
            return Sites.Where(a => a.Id == id).Select(s => s.CurrencyCode).FirstOrDefault();
        }
    }

    public class WebSiteModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string CurrencyCode { get; set; }
    }
}
