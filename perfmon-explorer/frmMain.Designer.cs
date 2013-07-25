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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.lstInstances = new System.Windows.Forms.ListBox();
            this.lstCounters = new System.Windows.Forms.ListBox();
            this.tlpRight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPath = new System.Windows.Forms.TableLayoutPanel();
            this.txtZabbixPath = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblZabbixPath = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtHelpCategory = new System.Windows.Forms.TextBox();
            this.txtHelpCounter = new System.Windows.Forms.TextBox();
            this.tlpValue = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetValue = new System.Windows.Forms.Button();
            this.lstValue = new System.Windows.Forms.ListBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblInstances = new System.Windows.Forms.Label();
            this.lblCounters = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpPath.SuspendLayout();
            this.tlpValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstCategory
            // 
            this.lstCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.Location = new System.Drawing.Point(3, 23);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.Size = new System.Drawing.Size(205, 217);
            this.lstCategory.TabIndex = 0;
            this.lstCategory.SelectedIndexChanged += new System.EventHandler(this.lstCategory_SelectedIndexChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(484, 562);
            this.tlpMain.TabIndex = 1;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.lstCategory, 0, 1);
            this.tlpLeft.Controls.Add(this.lstInstances, 0, 3);
            this.tlpLeft.Controls.Add(this.lstCounters, 0, 5);
            this.tlpLeft.Controls.Add(this.lblCategory, 0, 0);
            this.tlpLeft.Controls.Add(this.lblInstances, 0, 2);
            this.tlpLeft.Controls.Add(this.lblCounters, 0, 4);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 6;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLeft.Size = new System.Drawing.Size(211, 556);
            this.tlpLeft.TabIndex = 4;
            // 
            // lstInstances
            // 
            this.lstInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInstances.FormattingEnabled = true;
            this.lstInstances.Location = new System.Drawing.Point(3, 266);
            this.lstInstances.Name = "lstInstances";
            this.lstInstances.Size = new System.Drawing.Size(205, 43);
            this.lstInstances.TabIndex = 2;
            this.lstInstances.SelectedIndexChanged += new System.EventHandler(this.lstInstances_SelectedIndexChanged);
            // 
            // lstCounters
            // 
            this.lstCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCounters.FormattingEnabled = true;
            this.lstCounters.Location = new System.Drawing.Point(3, 335);
            this.lstCounters.Name = "lstCounters";
            this.lstCounters.Size = new System.Drawing.Size(205, 218);
            this.lstCounters.TabIndex = 1;
            this.lstCounters.SelectedIndexChanged += new System.EventHandler(this.lstCounters_SelectedIndexChanged);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tlpPath, 0, 0);
            this.tlpRight.Controls.Add(this.txtHelpCategory, 0, 2);
            this.tlpRight.Controls.Add(this.txtHelpCounter, 0, 3);
            this.tlpRight.Controls.Add(this.tlpValue, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(220, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 4;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRight.Size = new System.Drawing.Size(261, 556);
            this.tlpRight.TabIndex = 5;
            // 
            // tlpPath
            // 
            this.tlpPath.ColumnCount = 2;
            this.tlpPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPath.Controls.Add(this.txtZabbixPath, 1, 1);
            this.tlpPath.Controls.Add(this.txtPath, 1, 0);
            this.tlpPath.Controls.Add(this.lblZabbixPath, 0, 1);
            this.tlpPath.Controls.Add(this.lblPath, 0, 0);
            this.tlpPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPath.Location = new System.Drawing.Point(3, 3);
            this.tlpPath.Name = "tlpPath";
            this.tlpPath.RowCount = 2;
            this.tlpPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPath.Size = new System.Drawing.Size(255, 54);
            this.tlpPath.TabIndex = 10;
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
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(3, 3);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 13);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Categories";
            // 
            // lblInstances
            // 
            this.lblInstances.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblInstances.AutoSize = true;
            this.lblInstances.Location = new System.Drawing.Point(3, 246);
            this.lblInstances.Name = "lblInstances";
            this.lblInstances.Size = new System.Drawing.Size(53, 13);
            this.lblInstances.TabIndex = 4;
            this.lblInstances.Text = "Instances";
            // 
            // lblCounters
            // 
            this.lblCounters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCounters.AutoSize = true;
            this.lblCounters.Location = new System.Drawing.Point(3, 315);
            this.lblCounters.Name = "lblCounters";
            this.lblCounters.Size = new System.Drawing.Size(49, 13);
            this.lblCounters.TabIndex = 5;
            this.lblCounters.Text = "Counters";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 562);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Performance Monitor Analyser";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpLeft.PerformLayout();
            this.tlpRight.ResumeLayout(false);
            this.tlpRight.PerformLayout();
            this.tlpPath.ResumeLayout(false);
            this.tlpPath.PerformLayout();
            this.tlpValue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCategory;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ListBox lstCounters;
        private System.Windows.Forms.ListBox lstInstances;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private System.Windows.Forms.TableLayoutPanel tlpRight;
        private System.Windows.Forms.TableLayoutPanel tlpPath;
        private System.Windows.Forms.TextBox txtZabbixPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblZabbixPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtHelpCategory;
        private System.Windows.Forms.TextBox txtHelpCounter;
        private System.Windows.Forms.TableLayoutPanel tlpValue;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.ListBox lstValue;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblInstances;
        private System.Windows.Forms.Label lblCounters;
    }
}

