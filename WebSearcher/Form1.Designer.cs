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
            this.lstWebSites = new System.Windows.Forms.ListBox();
            this.lstSearchPoints = new System.Windows.Forms.ListBox();
            this.lstSearchKeywords = new System.Windows.Forms.ListBox();
            this.btnAddKeyword = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSearchResults = new System.Windows.Forms.ListBox();
            this.btnRemoveKeyword = new System.Windows.Forms.Button();
            this.btnSearchAdd = new System.Windows.Forms.Button();
            this.btnSearchRemove = new System.Windows.Forms.Button();
            this.btnSearchClear = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstWebSites
            // 
            this.lstWebSites.FormattingEnabled = true;
            this.lstWebSites.Location = new System.Drawing.Point(12, 12);
            this.lstWebSites.Name = "lstWebSites";
            this.lstWebSites.Size = new System.Drawing.Size(115, 277);
            this.lstWebSites.TabIndex = 0;
            // 
            // lstSearchPoints
            // 
            this.lstSearchPoints.FormattingEnabled = true;
            this.lstSearchPoints.Location = new System.Drawing.Point(6, 6);
            this.lstSearchPoints.Name = "lstSearchPoints";
            this.lstSearchPoints.Size = new System.Drawing.Size(588, 264);
            this.lstSearchPoints.TabIndex = 1;
            // 
            // lstSearchKeywords
            // 
            this.lstSearchKeywords.FormattingEnabled = true;
            this.lstSearchKeywords.Location = new System.Drawing.Point(3, 3);
            this.lstSearchKeywords.Name = "lstSearchKeywords";
            this.lstSearchKeywords.Size = new System.Drawing.Size(190, 329);
            this.lstSearchKeywords.TabIndex = 2;
            // 
            // btnAddKeyword
            // 
            this.btnAddKeyword.Location = new System.Drawing.Point(519, 4);
            this.btnAddKeyword.Name = "btnAddKeyword";
            this.btnAddKeyword.Size = new System.Drawing.Size(75, 23);
            this.btnAddKeyword.TabIndex = 3;
            this.btnAddKeyword.Text = "Add";
            this.btnAddKeyword.UseVisualStyleBackColor = true;
            this.btnAddKeyword.Click += new System.EventHandler(this.btnAddKeyword_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 6);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(507, 20);
            this.txtKeyword.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 484);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(600, 458);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "BOT Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSearchClear);
            this.tabPage1.Controls.Add(this.btnSearchRemove);
            this.tabPage1.Controls.Add(this.btnSearchAdd);
            this.tabPage1.Controls.Add(this.btnRemoveKeyword);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.txtKeyword);
            this.tabPage1.Controls.Add(this.btnAddKeyword);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(600, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(9, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstSearchKeywords);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstSearchResults);
            this.splitContainer1.Size = new System.Drawing.Size(588, 341);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstSearchPoints);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(600, 458);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reqisterated Ads";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lstWebSites);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(600, 458);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WebSites";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            // lstSearchResults
            // 
            this.lstSearchResults.FormattingEnabled = true;
            this.lstSearchResults.Location = new System.Drawing.Point(3, 3);
            this.lstSearchResults.Name = "lstSearchResults";
            this.lstSearchResults.Size = new System.Drawing.Size(382, 329);
            this.lstSearchResults.TabIndex = 0;
            // 
            // btnRemoveKeyword
            // 
            this.btnRemoveKeyword.BackColor = System.Drawing.Color.Red;
            this.btnRemoveKeyword.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRemoveKeyword.FlatAppearance.BorderSize = 0;
            this.btnRemoveKeyword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveKeyword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRemoveKeyword.Location = new System.Drawing.Point(9, 402);
            this.btnRemoveKeyword.Name = "btnRemoveKeyword";
            this.btnRemoveKeyword.Size = new System.Drawing.Size(193, 23);
            this.btnRemoveKeyword.TabIndex = 8;
            this.btnRemoveKeyword.Text = "Remove (keyword)";
            this.btnRemoveKeyword.UseVisualStyleBackColor = false;
            this.btnRemoveKeyword.Click += new System.EventHandler(this.btnRemoveKeyword_Click);
            // 
            // btnSearchAdd
            // 
            this.btnSearchAdd.BackColor = System.Drawing.Color.Lime;
            this.btnSearchAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchAdd.Location = new System.Drawing.Point(518, 402);
            this.btnSearchAdd.Name = "btnSearchAdd";
            this.btnSearchAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAdd.TabIndex = 9;
            this.btnSearchAdd.Text = "Register";
            this.btnSearchAdd.UseVisualStyleBackColor = false;
            // 
            // btnSearchRemove
            // 
            this.btnSearchRemove.BackColor = System.Drawing.Color.Red;
            this.btnSearchRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRemove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchRemove.Location = new System.Drawing.Point(437, 402);
            this.btnSearchRemove.Name = "btnSearchRemove";
            this.btnSearchRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSearchRemove.TabIndex = 10;
            this.btnSearchRemove.Text = "Remove";
            this.btnSearchRemove.UseVisualStyleBackColor = false;
            // 
            // btnSearchClear
            // 
            this.btnSearchClear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearchClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchClear.Location = new System.Drawing.Point(212, 402);
            this.btnSearchClear.Name = "btnSearchClear";
            this.btnSearchClear.Size = new System.Drawing.Size(75, 23);
            this.btnSearchClear.TabIndex = 11;
            this.btnSearchClear.Text = "Clear";
            this.btnSearchClear.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 503);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstWebSites;
        private System.Windows.Forms.ListBox lstSearchPoints;
        private System.Windows.Forms.ListBox lstSearchKeywords;
        private System.Windows.Forms.Button btnAddKeyword;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSearchClear;
        private System.Windows.Forms.Button btnSearchRemove;
        private System.Windows.Forms.Button btnSearchAdd;
        private System.Windows.Forms.Button btnRemoveKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSearchResults;
    }
}

