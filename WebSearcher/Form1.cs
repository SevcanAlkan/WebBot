using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSearcher.Data;

namespace WebSearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataContext.Load();
            this.UpdateForm();

            //https://www.hepsiburada.com/ara?q=
            //https://www.hepsiburada.com/ara?q=&sayfa=

            //var result = Get("https://www.hepsiburada.com/ara?q=audi");

            //SearchListing
            //search-item > div.box product > a : URL

            //search-item > div.box product > a >  product-detail > last-price > price-value : SPECIAL PRICE

            //  IF last-price not found, search price-container!

            //search-item > div.box product > a >  product-detail > price-container > product-price : PRICE

            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.hepsiburada.com/ara?q=iphone");
            //HtmlNodeCollection tags = doc.DocumentNode.SelectNodes("////tag");

            List<Items> itemList = new List<Items>();

            var ads = doc.DocumentNode.Descendants("li").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("search-item")).ToList();

            foreach (HtmlNode product in ads)
            {
                var productDetail = product.Descendants("div").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("product-detail")).FirstOrDefault();

                string name = productDetail.SelectSingleNode("//h3/div/p/span").InnerText;
                var url = product.Descendants("a").FirstOrDefault().Attributes.FirstOrDefault(a=> a.Name == "href");

                var priceValue = productDetail.Descendants("div").Where(d => d.Attributes.Count > 0
                && d.Attributes["class"] != null
                && d.Attributes["class"].Value.Contains("price-value")).Select(a => a.InnerText).FirstOrDefault();

                var productPrice = productDetail.Descendants("span").Where(d => d.Attributes.Count > 0
              && d.Attributes["class"] != null
              && d.Attributes["class"].Value.Contains("price product-price")).Select(a => a.InnerText).FirstOrDefault();

                double price = 0;
                if (priceValue != null)
                {
                    var priceStr = priceValue.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("TL", "").Replace(".","").Replace(",", ".");
                    price = Double.Parse(priceStr);
                }
                else if (productPrice != null)
                {
                    var priceStr = productPrice.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace(".", "").Replace(",", ".").Replace("TL", "");
                    price = Double.Parse(priceStr);
                }

                var rec = new Items() { Name = name, Price = price, URL = "" };
                itemList.Add(rec);
            }


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataContext.Save();
        }

        private void UpdateForm()
        {
            lstSearchKeywords.DataSource = null;
            lstSearchKeywords.DataSource = DataContext.Keywords;
            lstSearchKeywords.Refresh();
            lstSearchKeywords.Update();
        }

        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.txtKeyword.Text.Trim();

            if (this.txtKeyword.Text != "")
            {
                DataContext.AddKeyword(this.txtKeyword.Text);
                this.UpdateForm();
            }

            this.txtKeyword.Text = "";
        }

        private void btnRemoveKeyword_Click(object sender, EventArgs e)
        {
            string text = this.lstSearchKeywords.SelectedItem.ToString();

            if (text != "")
            {
                DataContext.RemoveKeyword(text);
                this.UpdateForm();
            }
        }

        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    class Items
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string URL { get; set; }
    }
}
