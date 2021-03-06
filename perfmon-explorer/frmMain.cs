﻿//
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
using System.Windows.Forms;

namespace perfmon_explorer
{
    public partial class frmMain : Form
    {
        int lastIdxCategory = -1;
        int lastIdxInstance = -1;
        int lastIdxCounter = -1;

        PerfMon.CounterPath counterPath = new PerfMon.CounterPath();

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
            if (lstCategory.SelectedIndex == -1 ||
                lstCategory.SelectedIndex == lastIdxCategory)
                return;

            lastIdxCategory = lstCategory.SelectedIndex;
            lastIdxInstance = -1;
            lastIdxCounter = -1;
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

            string[] instances = cat.EndGetInstancesNames(asyncResult);
            Array.Sort(instances);
            lstInstances.Items.AddRange(instances);
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

            counterPath = new PerfMon.CounterPath();
            counterPath.CategoryName = cat.ToString();
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private void lstInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInstances.SelectedIndex == -1 ||
                lstInstances.SelectedIndex == lastIdxInstance)
                return;

            lastIdxInstance = lstInstances.SelectedIndex;
            lastIdxCounter = -1;
            lstCounters.Items.Clear();
            txtHelpCounter.Text = string.Empty;
            btnGetValue.Enabled = false;
            lstValue.Items.Clear();

            PerfMon.Category cat = (PerfMon.Category)lstCategory.SelectedItem;
            string instance = (string)lstInstances.SelectedItem;

            IAsyncResult asyncResult = cat.BeginGetCounters(instance);
            frmLoading frm = new frmLoading(asyncResult);
            frm.ShowDialog(this);

            PerfMon.Counter[] counters = cat.EndGetCounters(asyncResult);
            Array.Sort(counters);
            lstCounters.Items.AddRange(counters);

            counterPath.InstanceName = instance;
            counterPath.CounterId = -1;
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private void lstCounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCounters.SelectedIndex == -1 ||
                lstCounters.SelectedIndex == lastIdxCounter)
                return;

            lastIdxCounter = lstCounters.SelectedIndex;
            PerfMon.Counter counter = (PerfMon.Counter)lstCounters.SelectedItem;
            txtHelpCounter.Text = counter.Help;

            btnGetValue.Enabled = true;
            lstValue.Items.Clear();

            counterPath.CounterName = counter.ToString();
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private void txtReadOnly_DoubleClick(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnGetValue_Click(object sender, EventArgs e)
        {
            PerfMon.Counter counter = (PerfMon.Counter)lstCounters.SelectedItem;
            float? nValue = float.NaN;
            long? rValue = long.MinValue;

            try { nValue = counter.NextValue(); }
            catch { }
            try { rValue = counter.RawValue; }
            catch { }

            string item = string.Format("{0} (Raw: {1})",
                nValue.ToString(),
                rValue == long.MinValue ? "NaN" : rValue.ToString());
            lstValue.Items.Insert(0, item);
        }
    }
}
