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
