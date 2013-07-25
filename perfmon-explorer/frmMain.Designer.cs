namespace perfmon_explorer
{
    partial class frmMain
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
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lstCounters = new System.Windows.Forms.ListBox();
            this.lstInstances = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtZabbixPath = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblZabbixPath = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtHelpCategory = new System.Windows.Forms.TextBox();
            this.txtHelpCounter = new System.Windows.Forms.TextBox();
            this.tlpValue = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.lstValue = new System.Windows.Forms.ListBox();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCategory
            // 
            this.lstCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(3, 3);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(205, 244);
            this.lstCategory.TabIndex = 0;
            this.lstCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(484, 562);
            this.tlpMain.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lstCounters, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lstCategory, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lstInstances, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(211, 556);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // lstCounters
            // 
            this.lstCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCounters.FormattingEnabled = true;
            this.lstCounters.Location = new System.Drawing.Point(3, 308);
            this.lstCounters.Name = "lstCounters";
            this.lstCounters.Size = new System.Drawing.Size(205, 245);
            this.lstCounters.TabIndex = 1;
            this.lstCounters.SelectedIndexChanged += new System.EventHandler(this.lstCounters_SelectedIndexChanged);
            // 
            // lstInstances
            // 
            this.lstInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInstances.FormattingEnabled = true;
            this.lstInstances.Location = new System.Drawing.Point(3, 253);
            this.lstInstances.Name = "lstInstances";
            this.lstInstances.Size = new System.Drawing.Size(205, 49);
            this.lstInstances.TabIndex = 2;
            this.lstInstances.SelectedIndexChanged += new System.EventHandler(this.lstInstances_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHelpCategory, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtHelpCounter, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tlpValue, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(220, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 556);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtZabbixPath, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtPath, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblZabbixPath, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblPath, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(255, 54);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // txtZabbixPath
            // 
            this.txtZabbixPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZabbixPath.Location = new System.Drawing.Point(83, 30);
            this.txtZabbixPath.Name = "txtZabbixPath";
            this.txtZabbixPath.ReadOnly = true;
            this.txtZabbixPath.Size = new System.Drawing.Size(169, 20);
            this.txtZabbixPath.TabIndex = 7;
            this.txtZabbixPath.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(83, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(169, 20);
            this.txtPath.TabIndex = 6;
            this.txtPath.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
            // 
            // lblZabbixPath
            // 
            this.lblZabbixPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblZabbixPath.AutoSize = true;
            this.lblZabbixPath.Location = new System.Drawing.Point(3, 34);
            this.lblZabbixPath.Name = "lblZabbixPath";
            this.lblZabbixPath.Size = new System.Drawing.Size(67, 13);
            this.lblZabbixPath.TabIndex = 5;
            this.lblZabbixPath.Text = "Zabbix Path:";
            // 
            // lblPath
            // 
            this.lblPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(3, 7);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 4;
            this.lblPath.Text = "Path:";
            // 
            // txtHelpCategory
            // 
            this.txtHelpCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelpCategory.Location = new System.Drawing.Point(3, 360);
            this.txtHelpCategory.Multiline = true;
            this.txtHelpCategory.Name = "txtHelpCategory";
            this.txtHelpCategory.ReadOnly = true;
            this.txtHelpCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHelpCategory.Size = new System.Drawing.Size(255, 93);
            this.txtHelpCategory.TabIndex = 13;
            this.txtHelpCategory.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
            // 
            // txtHelpCounter
            // 
            this.txtHelpCounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHelpCounter.Location = new System.Drawing.Point(3, 459);
            this.txtHelpCounter.Multiline = true;
            this.txtHelpCounter.Name = "txtHelpCounter";
            this.txtHelpCounter.ReadOnly = true;
            this.txtHelpCounter.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHelpCounter.Size = new System.Drawing.Size(255, 94);
            this.txtHelpCounter.TabIndex = 14;
            this.txtHelpCounter.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
            // 
            // tlpValue
            // 
            this.tlpValue.ColumnCount = 1;
            this.tlpValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpValue.Controls.Add(this.btnGetValue, 0, 0);
            this.tlpValue.Controls.Add(this.lstValue, 0, 1);
            this.tlpValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpValue.Location = new System.Drawing.Point(3, 63);
            this.tlpValue.Name = "tlpValue";
            this.tlpValue.RowCount = 2;
            this.tlpValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpValue.Size = new System.Drawing.Size(255, 291);
            this.tlpValue.TabIndex = 15;
            // 
            // btnGetValue
            // 
            this.btnGetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetValue.Enabled = false;
            this.btnGetValue.Location = new System.Drawing.Point(3, 3);
            this.btnGetValue.Name = "btnGetValue";
            this.btnGetValue.Size = new System.Drawing.Size(249, 24);
            this.btnGetValue.TabIndex = 0;
            this.btnGetValue.Text = "Get Value";
            this.btnGetValue.UseVisualStyleBackColor = true;
            this.btnGetValue.Click += new System.EventHandler(this.btnGetValue_Click);
            // 
            // lstValue
            // 
            this.lstValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstValue.FormattingEnabled = true;
            this.lstValue.Location = new System.Drawing.Point(3, 33);
            this.lstValue.Name = "lstValue";
            this.lstValue.Size = new System.Drawing.Size(249, 255);
            this.lstValue.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmMain";
            this.Text = "Performance Monitor Analyser";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tlpValue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ListBox lstCounters;
        private System.Windows.Forms.ListBox lstInstances;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtZabbixPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblZabbixPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtHelpCategory;
        private System.Windows.Forms.TextBox txtHelpCounter;
        private System.Windows.Forms.TableLayoutPanel tlpValue;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.ListBox lstValue;
    }
}

