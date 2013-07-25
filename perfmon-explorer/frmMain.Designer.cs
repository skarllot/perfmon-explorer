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
            this.lstCounters = new System.Windows.Forms.ListBox();
            this.lstInstances = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblZabbixPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtZabbixPath = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCategory
            // 
            this.lstCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(3, 3);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(211, 246);
            this.lstCategory.TabIndex = 0;
            this.lstCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.Controls.Add(this.lstCategory, 0, 0);
            this.tlpMain.Controls.Add(this.lstCounters, 0, 2);
            this.tlpMain.Controls.Add(this.lstInstances, 0, 1);
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Size = new System.Drawing.Size(484, 562);
            this.tlpMain.TabIndex = 1;
            // 
            // lstCounters
            // 
            this.lstCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCounters.FormattingEnabled = true;
            this.lstCounters.Location = new System.Drawing.Point(3, 311);
            this.lstCounters.Name = "lstCounters";
            this.lstCounters.Size = new System.Drawing.Size(211, 248);
            this.lstCounters.TabIndex = 1;
            this.lstCounters.SelectedIndexChanged += new System.EventHandler(this.lstCounters_SelectedIndexChanged);
            // 
            // lstInstances
            // 
            this.lstInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInstances.FormattingEnabled = true;
            this.lstInstances.Location = new System.Drawing.Point(3, 255);
            this.lstInstances.Name = "lstInstances";
            this.lstInstances.Size = new System.Drawing.Size(211, 50);
            this.lstInstances.TabIndex = 2;
            this.lstInstances.SelectedIndexChanged += new System.EventHandler(this.lstInstances_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblPath, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblZabbixPath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtZabbixPath, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(220, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 100);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblPath
            // 
            this.lblPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(3, 18);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            // 
            // lblZabbixPath
            // 
            this.lblZabbixPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblZabbixPath.AutoSize = true;
            this.lblZabbixPath.Location = new System.Drawing.Point(3, 68);
            this.lblZabbixPath.Name = "lblZabbixPath";
            this.lblZabbixPath.Size = new System.Drawing.Size(67, 13);
            this.lblZabbixPath.TabIndex = 1;
            this.lblZabbixPath.Text = "Zabbix Path:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(83, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(175, 20);
            this.txtPath.TabIndex = 2;
            this.txtPath.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
            // 
            // txtZabbixPath
            // 
            this.txtZabbixPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZabbixPath.Location = new System.Drawing.Point(83, 65);
            this.txtZabbixPath.Name = "txtZabbixPath";
            this.txtZabbixPath.ReadOnly = true;
            this.txtZabbixPath.Size = new System.Drawing.Size(175, 20);
            this.txtZabbixPath.TabIndex = 3;
            this.txtZabbixPath.DoubleClick += new System.EventHandler(this.txtReadOnly_DoubleClick);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ListBox lstCounters;
        private System.Windows.Forms.ListBox lstInstances;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblZabbixPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtZabbixPath;
    }
}

