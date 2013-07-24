using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace perfmon_explorer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show(this);

            PerfMon.Category[] categories = PerfMon.Category.GetCategories();
            Array.Sort(categories);
            lstCategory.Items.AddRange(categories);

            frm.Close();
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show(this);

            lstInstances.Items.Clear();
            lstCounters.Items.Clear();

            PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;
            lstInstances.Items.AddRange(cat.GetInstancesNames());

            if (lstInstances.Items.Count == 0)
            {
                PerfMon.Counter[] counters = cat.GetCounters(null);
                Array.Sort(counters);
                lstCounters.Items.AddRange(counters);
            }

            frm.Close();
        }

        private void lstInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            frmLoading frm = new frmLoading();
            frm.Show(this);

            lstCounters.Items.Clear();

            PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;

            PerfMon.Counter[] counters = cat.GetCounters((string)lstInstances.SelectedItem);
            Array.Sort(counters);
            lstCounters.Items.AddRange(counters);

            frm.Close();
        }
    }
}
