namespace WebSearcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstSearchKeywords = new System.Windows.Forms.ListBox();
            this.btnAddKeyword = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbBot = new System.Windows.Forms.TabPage();
            this.tbSearch = new System.Windows.Forms.TabPage();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.btnSearchClear = new System.Windows.Forms.Button();
            this.btnSearchRemove = new System.Windows.Forms.Button();
            this.btnSearchAdd = new System.Windows.Forms.Button();
            this.btnRemoveKeyword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAds = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.cbWebSite = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCheckDate = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCorrency = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnClearRegistrationFrom = new System.Windows.Forms.Button();
            this.lblTestStatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnShow = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabControl1.SuspendLayout();
            this.tbSearch.SuspendLayout();
            this.tbAds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSearchKeywords
            // 
            this.lstSearchKeywords.FormattingEnabled = true;
            this.lstSearchKeywords.Location = new System.Drawing.Point(9, 54);
            this.lstSearchKeywords.Name = "lstSearchKeywords";
            this.lstSearchKeywords.Size = new System.Drawing.Size(190, 329);
            this.lstSearchKeywords.TabIndex = 2;
            // 
            // btnAddKeyword
            // 
            this.btnAddKeyword.Location = new System.Drawing.Point(519, 4);
            this.btnAddKeyword.Name = "btnAddKeyword";
            this.btnAddKeyword.Size = new System.Drawing.Size(152, 23);
            this.btnAddKeyword.TabIndex = 3;
            this.btnAddKeyword.Text = "Add To Search List";
            this.btnAddKeyword.UseVisualStyleBackColor = true;
            this.btnAddKeyword.Click += new System.EventHandler(this.btnAddKeyword_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 6);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(507, 20);
            this.txtKeyword.TabIndex = 4;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbBot);
            this.tabControl1.Controls.Add(this.tbSearch);
            this.tabControl1.Controls.Add(this.tbAds);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(948, 472);
            this.tabControl1.TabIndex = 5;
            // 
            // tbBot
            // 
            this.tbBot.Location = new System.Drawing.Point(4, 22);
            this.tbBot.Name = "tbBot";
            this.tbBot.Size = new System.Drawing.Size(940, 446);
            this.tbBot.TabIndex = 3;
            this.tbBot.Text = "BOT Control";
            this.tbBot.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Controls.Add(this.lstSearchResults);
            this.tbSearch.Controls.Add(this.btnSearchClear);
            this.tbSearch.Controls.Add(this.lstSearchKeywords);
            this.tbSearch.Controls.Add(this.btnSearchRemove);
            this.tbSearch.Controls.Add(this.btnSearchAdd);
            this.tbSearch.Controls.Add(this.btnRemoveKeyword);
            this.tbSearch.Controls.Add(this.label2);
            this.tbSearch.Controls.Add(this.label1);
            this.tbSearch.Controls.Add(this.txtKeyword);
            this.tbSearch.Controls.Add(this.btnAddKeyword);
            this.tbSearch.Location = new System.Drawing.Point(4, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tbSearch.Size = new System.Drawing.Size(940, 446);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.Text = "Search";
            this.tbSearch.UseVisualStyleBackColor = true;
            // 
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.Location = new System.Drawing.Point(212, 54);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(704, 329);
            this.lstSearchResults.TabIndex = 0;
            this.lstSearchResults.SelectedIndexChanged += new System.EventHandler(this.lstSearchResults_SelectedIndexChanged);
            // 
            // btnSearchClear
            // 
            this.btnSearchClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchClear.Location = new System.Drawing.Point(212, 389);
            this.btnSearchClear.Name = "btnSearchClear";
            this.btnSearchClear.Size = new System.Drawing.Size(75, 23);
            this.btnSearchClear.TabIndex = 11;
            this.btnSearchClear.Text = "Clear";
            this.btnSearchClear.UseVisualStyleBackColor = false;
            // 
            // btnSearchRemove
            // 
            this.btnSearchRemove.BackColor = System.Drawing.Color.Red;
            this.btnSearchRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchRemove.Location = new System.Drawing.Point(758, 389);
            this.btnSearchRemove.Name = "btnSearchRemove";
            this.btnSearchRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSearchRemove.TabIndex = 10;
            this.btnSearchRemove.Text = "Remove";
            this.btnSearchRemove.UseVisualStyleBackColor = false;
            // 
            // btnSearchAdd
            // 
            this.btnSearchAdd.BackColor = System.Drawing.Color.Lime;
            this.btnSearchAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchAdd.Location = new System.Drawing.Point(839, 389);
            this.btnSearchAdd.Name = "btnSearchAdd";
            this.btnSearchAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAdd.TabIndex = 9;
            this.btnSearchAdd.Text = "Register";
            this.btnSearchAdd.UseVisualStyleBackColor = false;
            // 
            // btnRemoveKeyword
            // 
            this.btnRemoveKeyword.BackColor = System.Drawing.Color.Red;
            this.btnRemoveKeyword.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRemoveKeyword.FlatAppearance.BorderSize = 0;
            this.btnRemoveKeyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveKeyword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveKeyword.Location = new System.Drawing.Point(9, 389);
            this.btnRemoveKeyword.Name = "btnRemoveKeyword";
            this.btnRemoveKeyword.Size = new System.Drawing.Size(193, 23);
            this.btnRemoveKeyword.TabIndex = 8;
            this.btnRemoveKeyword.Text = "Remove (keyword)";
            this.btnRemoveKeyword.UseVisualStyleBackColor = false;
            this.btnRemoveKeyword.Click += new System.EventHandler(this.btnRemoveKeyword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wainting Keywords To Search";
            // 
            // tbAds
            // 
            this.tbAds.Controls.Add(this.groupBox1);
            this.tbAds.Controls.Add(this.lblTestStatus);
            this.tbAds.Controls.Add(this.btnClearRegistrationFrom);
            this.tbAds.Controls.Add(this.btnTest);
            this.tbAds.Controls.Add(this.btnAdd);
            this.tbAds.Controls.Add(this.lblCorrency);
            this.tbAds.Controls.Add(this.textBox1);
            this.tbAds.Controls.Add(this.label8);
            this.tbAds.Controls.Add(this.label7);
            this.tbAds.Controls.Add(this.txtURL);
            this.tbAds.Controls.Add(this.label6);
            this.tbAds.Controls.Add(this.txtName);
            this.tbAds.Controls.Add(this.lblCheckDate);
            this.tbAds.Controls.Add(this.label5);
            this.tbAds.Controls.Add(this.label4);
            this.tbAds.Controls.Add(this.cbWebSite);
            this.tbAds.Controls.Add(this.lblId);
            this.tbAds.Controls.Add(this.label3);
            this.tbAds.Location = new System.Drawing.Point(4, 22);
            this.tbAds.Name = "tbAds";
            this.tbAds.Padding = new System.Windows.Forms.Padding(3);
            this.tbAds.Size = new System.Drawing.Size(940, 446);
            this.tbAds.TabIndex = 1;
            this.tbAds.Text = "Ads";
            this.tbAds.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(232, 7);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(10, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "-";
            // 
            // cbWebSite
            // 
            this.cbWebSite.FormattingEnabled = true;
            this.cbWebSite.Location = new System.Drawing.Point(235, 23);
            this.cbWebSite.Name = "cbWebSite";
            this.cbWebSite.Size = new System.Drawing.Size(298, 21);
            this.cbWebSite.TabIndex = 4;
            this.cbWebSite.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdsForm_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "WebSite:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Last Check Date:";
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.AutoSize = true;
            this.lblCheckDate.Location = new System.Drawing.Point(628, 6);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Size = new System.Drawing.Size(10, 13);
            this.lblCheckDate.TabIndex = 7;
            this.lblCheckDate.Text = "-";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(235, 51);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(298, 20);
            this.txtName.TabIndex = 8;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdsForm_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Product Name:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(235, 78);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(298, 20);
            this.txtURL.TabIndex = 10;
            this.txtURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdsForm_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Product URL:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Price:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(235, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(298, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AdsForm_Enter);
            // 
            // lblCorrency
            // 
            this.lblCorrency.AutoSize = true;
            this.lblCorrency.Location = new System.Drawing.Point(539, 108);
            this.lblCorrency.Name = "lblCorrency";
            this.lblCorrency.Size = new System.Drawing.Size(10, 13);
            this.lblCorrency.TabIndex = 14;
            this.lblCorrency.Text = "-";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(457, 132);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(376, 132);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 16;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnClearRegistrationFrom
            // 
            this.btnClearRegistrationFrom.Location = new System.Drawing.Point(235, 132);
            this.btnClearRegistrationFrom.Name = "btnClearRegistrationFrom";
            this.btnClearRegistrationFrom.Size = new System.Drawing.Size(75, 23);
            this.btnClearRegistrationFrom.TabIndex = 17;
            this.btnClearRegistrationFrom.Text = "Clear";
            this.btnClearRegistrationFrom.UseVisualStyleBackColor = true;
            // 
            // lblTestStatus
            // 
            this.lblTestStatus.AutoSize = true;
            this.lblTestStatus.Location = new System.Drawing.Point(539, 137);
            this.lblTestStatus.Name = "lblTestStatus";
            this.lblTestStatus.Size = new System.Drawing.Size(0, 13);
            this.lblTestStatus.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(928, 263);
            this.dataGridView1.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 282);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrated Ads";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnShow,
            this.toolStripSeparator1,
            this.tsBtnRemove});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(928, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnShow
            // 
            this.tsBtnShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnShow.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnShow.Image")));
            this.tsBtnShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnShow.Name = "tsBtnShow";
            this.tsBtnShow.Size = new System.Drawing.Size(80, 22);
            this.tsBtnShow.Text = "Show Record";
            // 
            // tsBtnRemove
            // 
            this.tsBtnRemove.BackColor = System.Drawing.Color.Red;
            this.tsBtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRemove.ForeColor = System.Drawing.Color.White;
            this.tsBtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRemove.Image")));
            this.tsBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemove.Name = "tsBtnRemove";
            this.tsBtnRemove.Size = new System.Drawing.Size(54, 22);
            this.tsBtnRemove.Text = "Remove";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(948, 472);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbSearch.ResumeLayout(false);
            this.tbSearch.PerformLayout();
            this.tbAds.ResumeLayout(false);
            this.tbAds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstSearchKeywords;
        private System.Windows.Forms.Button btnAddKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbBot;
        private System.Windows.Forms.TabPage tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbAds;
        private System.Windows.Forms.Button btnSearchClear;
        private System.Windows.Forms.Button btnSearchRemove;
        private System.Windows.Forms.Button btnSearchAdd;
        private System.Windows.Forms.Button btnRemoveKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSearchResults;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBtnShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnRemove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTestStatus;
        private System.Windows.Forms.Button btnClearRegistrationFrom;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblCorrency;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCheckDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbWebSite;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label3;
    }
}

