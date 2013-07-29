//
//  frmMain.cs
//
//  Author:
//       Fabricio Godoy <skarllot@gmail.com>
//
//  Copyright (c) 2013 Fabricio Godoy
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
            IAsyncResult asyncResult = PerfMon.Category.BeginGetCategories();
            frmLoading frm = new frmLoading(asyncResult);
            frm.ShowDialog(this);

            PerfMon.Category[] categories = PerfMon.Category.EndGetCategories(asyncResult);
            Array.Sort(categories);
            lstCategory.Items.AddRange(categories);
        }

        private void lstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstInstances.Items.Clear();
            lstCounters.Items.Clear();
            txtHelpCounter.Text = string.Empty;
            btnGetValue.Enabled = false;
            lstValue.Items.Clear();

            PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;
            IAsyncResult asyncResult = cat.BeginGetInstancesNames();
            frmLoading frm = new frmLoading(asyncResult);
            frm.ShowDialog(this);
            frm.Dispose();

            lstInstances.Items.AddRange(cat.EndGetInstancesNames(asyncResult));
            txtHelpCategory.Text = cat.Help;

            if (lstInstances.Items.Count == 0)
            {
                asyncResult = cat.BeginGetCounters(null);
                frm = new frmLoading(asyncResult);
                frm.ShowDialog(this);

                PerfMon.Counter[] counters = cat.EndGetCounters(asyncResult);
                Array.Sort(counters);
                lstCounters.Items.AddRange(counters);
            }

            UpdatePaths();
        }

        private void lstInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstCounters.Items.Clear();
            txtHelpCounter.Text = string.Empty;
            btnGetValue.Enabled = false;
            lstValue.Items.Clear();

            PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;

            IAsyncResult asyncResult = cat.BeginGetCounters((string)lstInstances.SelectedItem);
            frmLoading frm = new frmLoading(asyncResult);
            frm.ShowDialog(this);

            PerfMon.Counter[] counters = cat.EndGetCounters(asyncResult);
            Array.Sort(counters);
            lstCounters.Items.AddRange(counters);

            UpdatePaths();
        }

        private void lstCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            PerfMon.Counter counter = (PerfMon.Counter)lstCounters.SelectedItem;
            txtHelpCounter.Text = counter.Help;

            btnGetValue.Enabled = true;
            lstValue.Items.Clear();

            UpdatePaths();
        }

        private void UpdatePaths()
        {
            txtPath.Text = string.Empty;
            txtZabbixPath.Text = string.Empty;

            if (lstCategory.SelectedIndex != -1)
            {
                PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;

                txtPath.Text = "\\" + cat.ToString();
                txtZabbixPath.Text = "\\" + (PerfMon.Localization.GetId(cat.ToString()) ?? "?");
            }

            if (lstInstances.SelectedIndex != -1)
            {
                txtPath.Text += "(" + (string)lstInstances.SelectedItem + ")";
                txtZabbixPath.Text += "(" + (string)lstInstances.SelectedItem + ")";
            }

            if (lstCounters.SelectedIndex != -1)
            {
                PerfMon.Counter counter = (PerfMon.Counter)lstCounters.SelectedItem;

                txtPath.Text += "\\" + counter.ToString();
                txtZabbixPath.Text += "\\" + (PerfMon.Localization.GetId(counter.ToString()) ?? "?");
            }
        }

        private void txtReadOnly_DoubleClick(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            PerfMon.Counter counter = (PerfMon.Counter)lstCounters.SelectedItem;
            string item = counter.RawValue.ToString() + " - " + counter.NextValue().ToString();
            lstValue.Items.Insert(0, item);
        }
    }
}
