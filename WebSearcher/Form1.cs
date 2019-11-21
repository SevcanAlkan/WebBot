using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        private List<ItemListVM> SearchResults;
        private static Scanner SC;
        private SearchPoint Rec;
        private bool BotIsActive;

        private Timer BotTimer;
        private BackgroundWorker SearchBW;

        private List<string> Log;

        public Form1()
        {
            InitializeComponent();

            SearchResults = new List<ItemListVM>();
            SC = new Scanner();
            BotTimer = new Timer();
            SearchBW = new BackgroundWorker();
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
            this.Log = new List<string>();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.AddLog("Program loading...");

            this.AddLog("Keywords loading...");
            KeywordContext.Load();
            this.AddLog("WebSites loading...");
            WebSiteContext.Load();
            this.UpdateKeywordList();
            this.AddLog("UI Components loading...");
            this.LoadDataGrids();
            this.AddLog("Bot settings are loaded, Bot is diseabled!");
            this.BotIsActive = false;
          

            cbWebSite.DataSource = WebSiteContext.Sites;
            cbWebSite.DisplayMember = "Name";
            cbWebSite.ValueMember = "Id";

            cbBotStatus.DataSource = Enum.GetValues(typeof(BotStatusEnum));

            BotTimer.Interval = 15000;
            BotTimer.Tick += new EventHandler(timer_Tick);
            BotTimer.Start();

            this.AddLog("Program succesfully loaded!");
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            this.AddLog("Background worker started.");
            Search();
            UpdateKeywordList();

            if (this.BotIsActive)
            {
                await Task.Run(() =>
                {
                    DateTime compareDate = DateTime.Now.AddDays(-1);
                    var recs = DataContext.searchPoints.Where(a => DbFunctions.DiffDays(a.CheckDate, compareDate) > 0).ToList();

                    if (recs != null)
                    {
                        this.AddLog("Ads Prices are updating...");
                        foreach (var item in recs)
                        {
                            var rec = SC.HPUpdateAd(item);
                            item.Price = rec.Price;
                            item.CheckDate = DateTime.Now;
                        }

                        DataContext.SaveChanges();

                        this.AddLog("Ads Prices are updated!");
                    }
                });
            }

            this.AddLog("Background worker completed its tasks.");
        }

        private void Search()
        {
            if (KeywordContext.Keywords.Count > 0)
            {
                this.AddLog("A Keyword Searcing...");
                var result = SC.HPScanAds(KeywordContext.TakeKeyword(), 3);

                if (result != null && result.Count > 0)
                {
                    SearchResults.AddRange(result);
                    UpdateKeywordList();
                }
                this.AddLog("Keyword Search Copleted!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //searchTask.Dispose();
            //t.Stop();
            KeywordContext.Save();
        }

        private void LoadDataGrids()
        {
            #region Search Grid
            var bindingList = new BindingList<ItemListVM>(SearchResults);
            var source = new BindingSource(bindingList, null);
            dgSearch.DataSource = source;

            dgSearch.Columns.Add("PriceStr", "Price");
            dgSearch.Columns.Add("WebSiteStr", "WebSite");

            dgSearch.Columns["Id"].Visible = false;
            dgSearch.Columns["Id"].DisplayIndex = 0;

            dgSearch.Columns["WebSiteId"].DisplayIndex = 1;
            dgSearch.Columns["WebSiteId"].Visible = false;

            dgSearch.Columns["WebSiteStr"].DisplayIndex = 2;

            dgSearch.Columns["Name"].DisplayIndex = 3;
            dgSearch.Columns["Name"].Width = 300;

            dgSearch.Columns["Price"].DisplayIndex = 4;
            dgSearch.Columns["Price"].Visible = false;

            dgSearch.Columns["PriceStr"].DisplayIndex = 5;
            dgSearch.Columns["PriceStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgSearch.Columns["URL"].DisplayIndex = 6;
            dgSearch.Columns["URL"].Width = 1000;

            dgAds.AutoResizeColumns();
            #endregion

            #region Ads Grid
            DataContext.searchPoints.Load();
            dgAds.DataSource = DataContext.searchPoints.Local.ToBindingList();

            dgAds.Columns.Add("PriceStr", "Price");
            dgAds.Columns.Add("WebSiteStr", "WebSite");

            dgAds.Columns["Id"].Visible = false;
            dgAds.Columns["Id"].DisplayIndex = 0;

            dgAds.Columns["Name"].DisplayIndex = 1;
            dgAds.Columns["Name"].Width = 300;

            dgAds.Columns["CheckDate"].DisplayIndex = 2;
            dgAds.Columns["CheckDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
            dgAds.Columns["CheckDate"].HeaderText = "Last Check Date";
            dgAds.Columns["CheckDate"].Width = 150;

            dgAds.Columns["WebSite"].DisplayIndex = 3;
            dgAds.Columns["WebSite"].Visible = false;
            dgAds.Columns["WebSiteStr"].DisplayIndex = 4;

            dgAds.Columns["Price"].DisplayIndex = 4;
            dgAds.Columns["Price"].Visible = false;
            dgAds.Columns["PriceStr"].DisplayIndex = 5;
            dgAds.Columns["PriceStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgAds.Columns["UrlParameters"].DisplayIndex = 6;
            dgAds.Columns["UrlParameters"].HeaderText = "URL";
            dgAds.Columns["UrlParameters"].Width = 1000;

            dgAds.AutoResizeColumns();
            #endregion
        }

        private void UpdateKeywordList()
        {
            lstSearchKeywords.DataSource = null;
            lstSearchKeywords.DataSource = KeywordContext.Keywords;
            lstSearchKeywords.Refresh();
            lstSearchKeywords.Update();
        }

        private void btnRemoveKeyword_Click(object sender, EventArgs e)
        {
            string text = this.lstSearchKeywords.SelectedItem.ToString();

            if (text != "")
            {
                KeywordContext.RemoveKeyword(text);
                this.UpdateKeywordList();
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

                this.UpdateKeywordList();
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
            try
            {
                if (Rec != null)
                {
                    DataContext.searchPoints.Add(Rec);
                    DataContext.SaveChanges();

                    dgAds_BindingContextChanged(this, new EventArgs());
                }

                btnClearRegistrationFrom.PerformClick();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchClear_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchRemove_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchAdd_Click(object sender, EventArgs e)
        {

        }

        private void dgAds_BindingContextChanged(object sender, EventArgs e)
        {
            if (dgAds.Rows != null && dgAds.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgAds.Rows)
                {
                    //Website
                    int websiteNum = (int)row.Cells["WebSite"].Value;
                    row.Cells["WebSiteStr"].Value = WebSiteContext.GetName(websiteNum);

                    //Price
                    double price = (double)row.Cells["Price"].Value;
                    row.Cells["PriceStr"].Value = String.Format("{0:00}", price) + " " + WebSiteContext.GetCurrencyCode(websiteNum);

                }
            }
        }
        private void dgSearch_BindingContextChanged(object sender, EventArgs e)
        {
            if (dgSearch.Rows != null && dgSearch.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgSearch.Rows)
                {
                    //Website
                    int websiteNum = (int)row.Cells["WebSite"].Value;
                    row.Cells["WebSiteStr"].Value = WebSiteContext.GetName(websiteNum);

                    //Price
                    double price = (double)row.Cells["Price"].Value;
                    row.Cells["PriceStr"].Value = String.Format("{0:00}", price) + " " + WebSiteContext.GetCurrencyCode(websiteNum);

                }
            }
        }

        private void tsBtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var rowIndex = dgAds.CurrentCell.RowIndex;
                var id = (Guid)dgAds.Rows[rowIndex].Cells["Id"].Value;

                if (id != null && id != Guid.Empty)
                {
                    var gridRec = DataContext.searchPoints.Where(a => a.Id == id).FirstOrDefault();

                    if (gridRec != null)
                    {
                        if (MessageBox.Show("Kaydi silmek istiyor musunuz?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DataContext.searchPoints.Remove(gridRec);
                            DataContext.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsBtnShow_Click(object sender, EventArgs e)
        {
            var rowIndex = dgAds.CurrentCell.RowIndex;
            var id = (Guid)dgAds.Rows[rowIndex].Cells["Id"].Value;

            if (id != null && id != Guid.Empty)
            {
                var gridRec = DataContext.searchPoints.Where(a => a.Id == id).FirstOrDefault();

                if (gridRec != null)
                {
                    Rec = gridRec;

                    btnTest.Enabled = false;
                    txtName.Enabled = false;
                    txtURL.Enabled = false;
                }
            }

            FillForm();
        }

        private void btnClearRegistrationFrom_Click(object sender, EventArgs e)
        {
            lblId.Text = "-";
            lblCheckDate.Text = "-";
            cbWebSite.SelectedItem = null;
            txtName.Text = "";
            txtURL.Text = "";
            txtPrice.Text = "";
            lblCurrency.Text = "";
            lblTestStatus.Text = "";
            btnAdd.Enabled = false;
            cbWebSite.Enabled = true;
            btnTest.Enabled = true;
            txtName.Enabled = true;
            txtURL.Enabled = true;

            Rec = null;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (cbWebSite.SelectedItem == null || txtURL.Text == "" || WebSiteContext.GetModel(((WebSiteModel)cbWebSite.SelectedItem).Id) == null)
            {
                MessageBox.Show("Lutfen gerekli alanlari oldurun!", "Uyari", MessageBoxButtons.OK);
                return;
            }

            if (DataContext.IsSearchPointExist(txtURL.Text))
            {
                MessageBox.Show("Ilan hali hazirlda kayitli!", "Uyari", MessageBoxButtons.OK);
                return;
            }

            WebSiteModel site = (WebSiteModel)cbWebSite.SelectedItem;

            switch (site.Id)
            {
                case 1:
                    Rec = SC.HPScanAd(txtURL.Text);
                    break;
                case 2:
                    Rec = SC.N11ScanAd(txtURL.Text);
                    break;
                default:
                    break;
            }

            if (Rec == null)
            {
                lblTestStatus.ForeColor = Color.Red;
                lblTestStatus.Text = "Operation failed!";
                btnAdd.Enabled = false;
            }
            else
            {
                if (txtName.Text != "")
                {
                    string tempText = txtName.Text;
                    FillForm();
                    txtName.Text = tempText;
                    Rec.Name = tempText;
                }
                else
                {
                    FillForm();
                }

                lblTestStatus.ForeColor = Color.Green;
                lblTestStatus.Text = "Operation succecful!";
                btnAdd.Enabled = true;
            }
        }

        private void FillForm()
        {
            lblId.Text = Rec.Id.ToString();
            txtName.Text = Rec.Name;
            txtURL.Text = Rec.UrlParameters;
            cbWebSite.SelectedItem = WebSiteContext.GetModel(Rec.WebSite);
            lblCheckDate.Text = String.Format("{0:dd/MM/yyyy hh:mm:ss tt}", Rec.CheckDate);
            txtPrice.Text = String.Format("{0:00}", Rec.Price);
            lblCurrency.Text = WebSiteContext.GetCurrencyCode(Rec.WebSite);

            cbWebSite.Enabled = false;
        }

        private void cbBotStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            BotStatusEnum status;
            Enum.TryParse<BotStatusEnum>(cbBotStatus.SelectedValue.ToString(), out status);

            switch (status)
            {
                case BotStatusEnum.Active:
                    this.BotIsActive = true;
                    this.lblBotStatus.Text = "Bot is working!";
                    this.lblBotStatus.ForeColor = Color.Green;
                    this.AddLog("BOT Activated!");
                    break;
                case BotStatusEnum.DeActive:
                    this.BotIsActive = false;
                    this.lblBotStatus.Text = "Bot is not working!";
                    this.lblBotStatus.ForeColor = Color.Red;
                    this.AddLog("BOT DeActivated!");
                    break;
            }
        }

        private void AddLog(object o)
        {
            try
            {
                this.Log.Add(String.Format("{0:dd/MM/yyyy hh:mm:ss tt} : {1}", DateTime.Now, o.ToString()));
            }
            catch (Exception e)
            {
                this.Log.Add("ERROR /-----------------------------------------------/");
                this.Log.Add(e.ToString());
                this.Log.Add("------------------------------------------------------/");
            }
            finally
            {
                lstLog.DataSource = null;
                lstLog.DataSource = this.Log;
                lstLog.Refresh();
                lstLog.Update();
            }
        }
    }

}
