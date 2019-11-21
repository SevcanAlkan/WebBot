using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSearcher.Data;
using WebSearcher.Models;

namespace WebSearcher.Helper
{
    public class Scanner
    {
        #region Hepsiburada
        //https://www.hepsiburada.com/ara?q=
        //https://www.hepsiburada.com/ara?q=&sayfa=

        //var result = Get("https://www.hepsiburada.com/ara?q=audi");

        //SearchListing
        //search-item > div.box product > a : URL
        //search-item > div.box product > a >  product-detail > last-price > price-value : SPECIAL PRICE
        //search-item > div.box product > a >  product-detail > price-container > product-price : PRICE

        public List<ItemListVM> HPScanAds(string keyword, int webSiteId, int pageLimit = 0)
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

                HPProcessSearchPage(ref doc, ref itemList, ref webSiteId);
            }

            return itemList;
        }
        private void HPProcessSearchPage(ref HtmlAgilityPack.HtmlDocument doc, ref List<ItemListVM> itemList, ref int webSiteId)
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

                var rec = new ItemListVM() { Id = Guid.NewGuid(), WebSiteId = webSiteId, Name = name, Price = price, URL = url };
                itemList.Add(rec);
            }
        }

        public SearchPoint HPScanAd(string url)
        {
            SearchPoint rec = new SearchPoint();
            rec.Id = Guid.NewGuid();
            rec.WebSite = 1;
            rec.CheckDate = DateTime.Now;
            rec.UrlParameters = url.Trim();

            try
            {
                if (rec.UrlParameters.Substring(0, 1) != "/")
                {
                    rec.UrlParameters = "/" + rec.UrlParameters;
                }

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(WebSiteContext.GetURL(rec.WebSite) + rec.UrlParameters);

                var price = doc.DocumentNode.Descendants("span").Where(d => d.Attributes.Count > 0
                    && d.Attributes["id"] != null && d.Attributes["id"].Value.Contains("offering-price")).Select(a => a.Attributes["content"]).FirstOrDefault();

                if(price!=null)
                rec.Price = Convert.ToDouble(price.Value);

                string priceDiscounted = "";
                try
                {
                    priceDiscounted = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Count > 0
                    && d.Attributes["class"] != null && d.Attributes["class"].Value.Contains("extra-discount-price")).Select(a => a.ChildNodes.Descendants("span").FirstOrDefault().InnerText).FirstOrDefault();

                    rec.Price = Convert.ToDouble(priceDiscounted);
                }
                catch (Exception)
                {
                    if(price == null)
                    {
                        return null;
                    }
                }
                
                var name = doc.DocumentNode.Descendants("h1").Where(d => d.Attributes.Count > 0
                   && d.Attributes["id"] != null && d.Attributes["id"].Value.Contains("product-name")).FirstOrDefault().InnerText;

                rec.Name = name.Trim().Replace("\r", "").Replace("\n", "");
            }
            catch (Exception e)
            {
                return null;
            }

            return rec;
        }

        public SearchPoint HPUpdateAd(SearchPoint rec)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(WebSiteContext.GetURL(rec.WebSite) + rec.UrlParameters);

                var price = doc.DocumentNode.Descendants("span").Where(d => d.Attributes.Count > 0
                    && d.Attributes["id"] != null && d.Attributes["id"].Value.Contains("offering-price")).Select(a => a.Attributes["content"]).FirstOrDefault();

                if (price != null)
                    rec.Price = Convert.ToDouble(price.Value);

                string priceDiscounted = "";
                try
                {
                    priceDiscounted = doc.DocumentNode.Descendants("div").Where(d => d.Attributes.Count > 0
                    && d.Attributes["class"] != null && d.Attributes["class"].Value.Contains("extra-discount-price")).Select(a => a.ChildNodes.Descendants("span").FirstOrDefault().InnerText).FirstOrDefault();

                    rec.Price = Convert.ToDouble(priceDiscounted);
                }
                catch (Exception)
                {
                    if (price == null)
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return rec;
        }

        #endregion

        #region N11

        public SearchPoint N11ScanAd(string url)
        {
            return new SearchPoint();
        }

        #endregion
    }
}
