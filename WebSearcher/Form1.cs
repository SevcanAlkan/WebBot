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
using WebSearcher.Helper;
using WebSearcher.Models;

namespace WebSearcher
{
    public partial class Form1 : Form
    {
        private static List<ItemListVM> SearchResults = new List<ItemListVM>();
        private static Scanner sc = new Scanner();
        //Task searchTask;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataContext.Load();
            this.UpdateForm();

            //searchTask = Task.Run((Action)Search);

            //t.Interval = 15000; // specify interval time as you want
            //t.Tick += new EventHandler(timer_Tick);
            //t.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void Search()
        {
            if (DataContext.Keywords.Count > 0)
            {
                var result = sc.ScanAds(DataContext.TakeKeyword(), 3);

                if (result != null && result.Count > 0)
                {
                    SearchResults.AddRange(result);
                    UpdateForm();
                }
            }

            MessageBox.Show("Task Worked");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //searchTask.Dispose();
            //t.Stop();
            DataContext.Save();
        }

        private void UpdateForm()
        {
            lstSearchKeywords.DataSource = null;
            lstSearchKeywords.DataSource = DataContext.Keywords;
            lstSearchKeywords.Refresh();
            lstSearchKeywords.Update();

            lstSearchResults.DataSource = null;
            lstSearchResults.DataSource = SearchResults;
            lstSearchResults.Refresh();
            lstSearchResults.Update();
        }

        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.txtKeyword.Text.Trim();

            if (this.txtKeyword.Text != "")
            {
                DataContext.AddKeyword(this.txtKeyword.Text);
                Task.Factory.StartNew(Search, TaskCreationOptions.LongRunning);

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

}
