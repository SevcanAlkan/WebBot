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
        private DataContext _db;
        private static List<ItemListVM> SearchResults = new List<ItemListVM>();
        private static Scanner sc = new Scanner();
        //Task searchTask;
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();

            var recs = DataContext.Set<SearchPoint>().ToList();

            SearchPoint s = new SearchPoint() { CheckDate = DateTime.UtcNow, Id = Guid.NewGuid(), Price = 2110.3, UrlParameters = "2331", WebSite = 1 };

            DataContext.Set<SearchPoint>().Add(s);
            DataContext.SaveChanges();
        }

        private DataContext DataContext
        {
            get
            {
                if (_db == null)
                {
                    _db = new DataContext();
                }

                return _db;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeywordContext.Load();
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
            if (KeywordContext.Keywords.Count > 0)
            {
                var result = sc.HPScanAds(KeywordContext.TakeKeyword(), 3);

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
            KeywordContext.Save();
        }

        private void UpdateForm()
        {
            lstSearchKeywords.DataSource = null;
            lstSearchKeywords.DataSource = KeywordContext.Keywords;
            lstSearchKeywords.Refresh();
            lstSearchKeywords.Update();

            lstSearchResults.DataSource = null;
            lstSearchResults.DataSource = SearchResults;
            lstSearchResults.Refresh();
            lstSearchResults.Update();
        }

        private void btnRemoveKeyword_Click(object sender, EventArgs e)
        {
            string text = this.lstSearchKeywords.SelectedItem.ToString();

            if (text != "")
            {
                KeywordContext.RemoveKeyword(text);
                this.UpdateForm();
            }
        }
        
        private void lstSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddKeyword.PerformClick();
            }
        }

        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            this.txtKeyword.Text = this.txtKeyword.Text.Trim();

            if (this.txtKeyword.Text != "")
            {
                KeywordContext.AddKeyword(this.txtKeyword.Text);
                Task.Factory.StartNew(Search, TaskCreationOptions.LongRunning);

                this.UpdateForm();
            }

            this.txtKeyword.Text = "";
        }

        private void AdsForm_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.PerformClick();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }

}
