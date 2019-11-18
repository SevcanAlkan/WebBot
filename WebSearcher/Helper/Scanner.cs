using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSearcher.Models;

namespace WebSearcher.Helper
{
    public class Scanner
    {
        //https://www.hepsiburada.com/ara?q=
        //https://www.hepsiburada.com/ara?q=&sayfa=

        //var result = Get("https://www.hepsiburada.com/ara?q=audi");

        //SearchListing
        //search-item > div.box product > a : URL

        //search-item > div.box product > a >  product-detail > last-price > price-value : SPECIAL PRICE

        //  IF last-price not found, search price-container!

        //search-item > div.box product > a >  product-detail > price-container > product-price : PRICE

        public List<ItemListVM> ScanAds(string keyword, int pageLimit = 0)
        {
            if (keyword == "")
                return new List<ItemListVM>();

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.hepsiburada.com/ara?q=" + keyword);

            int pageCount = 0;
            List<ItemListVM> itemList = new List<ItemListVM>();

            var pagination = doc.DocumentNode.SelectSingleNode("//div[@id='pagination']/ul");
            if (pagination != null)
            {
                var pages = pagination.Descendants("li").ToList();
                var lastPage = pages.Last().Descendants("a").FirstOrDefault().InnerText;

                if (lastPage != null || lastPage != "")
                {
                    if (int.TryParse(lastPage, out pageCount))
                    {

                    }
                }
            }

            if (pageLimit > 0 && pageLimit < pageCount)
                pageCount = pageLimit;
            
            for (int i = 1; i <= pageCount; i++)
            {
                if (i != 1)
                {
                    doc = web.Load($"https://www.hepsiburada.com/ara?q=" + keyword + "&sayfa=" + i.ToString());
                }

                processSearchPage(ref doc, ref itemList);
            }

            return itemList;
        }
        private void processSearchPage(ref HtmlAgilityPack.HtmlDocument doc, ref List<ItemListVM> itemList)
        {
            var ads = doc.DocumentNode.Descendants("li").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("search-item")).ToList();

            foreach (HtmlNode product in ads)
            {
                var productDetail = product.Descendants("div").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("product-detail")).FirstOrDefault();

                string name = productDetail.SelectSingleNode("//h3/div/p/span").InnerText;
                var url = product.Descendants("a").FirstOrDefault().Attributes.Where(a => a.Name == "href").Select(s => s.Value).FirstOrDefault();

                var priceValue = productDetail.Descendants("div").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("price-value")).Select(a => a.InnerText).FirstOrDefault();

                var productPrice = productDetail.Descendants("span").Where(d => d.Attributes.Count > 0
              && d.Attributes["class"] != null
              && d.Attributes["class"].Value.Contains("price product-price")).Select(a => a.InnerText).FirstOrDefault();

                double price = 0;
                if (priceValue != null)
                {
                    var priceStr = priceValue.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("TL", "").Replace(".", "").Replace(",", ".");
                    price = Double.Parse(priceStr);
                }
                else if (productPrice != null)
                {
                    var priceStr = productPrice.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace(".", "").Replace(",", ".").Replace("TL", "");
                    price = Double.Parse(priceStr);
                }

                var rec = new ItemListVM() { Name = name, Price = price, URL = url };
                itemList.Add(rec);
            }
        }

    }
}
