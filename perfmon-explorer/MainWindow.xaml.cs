using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace perfmon_explorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int lastIdxCategory = -1;
        private int lastIdxInstance = -1;
        private int lastIdxCounter = -1;

        private PerfMon.CounterPath counterPath = new PerfMon.CounterPath();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MainWindow_OnLoaded(object sender, EventArgs e)
        {
            var categories = await LoadingWindow.AwaitResult(this, PerfMon.Category.GetCategoriesAsync());
            lstCategory.Items.AddRange(categories.OrderBy(it => it.ToString(), StringComparer.Ordinal));
        }

        private async void LstCategory_OnSelected(object sender, RoutedEventArgs e)
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
            btnGetValue.IsEnabled = false;
            lstValue.Items.Clear();

            var cat = (PerfMon.Category)lstCategory.SelectedItem;

            var instances = await LoadingWindow.AwaitResult(this, cat.GetInstancesNamesAsync());
            Array.Sort(instances);
            lstInstances.Items.AddRange(instances);
            txtHelpCategory.Text = cat.Help;

            if (lstInstances.Items.Count == 0)
            {
                var counters = await LoadingWindow.AwaitResult(this, cat.GetCountersAsync(null));
                lstCounters.Items.AddRange(counters.OrderBy(it => it.ToString(), StringComparer.Ordinal));
            }

            counterPath = new PerfMon.CounterPath();
            counterPath.CategoryName = cat.ToString();
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private async void LstInstances_OnSelected(object sender, RoutedEventArgs e)
        {
            if (lstInstances.SelectedIndex == -1 ||
                lstInstances.SelectedIndex == lastIdxInstance)
                return;

            lastIdxInstance = lstInstances.SelectedIndex;
            lastIdxCounter = -1;
            lstCounters.Items.Clear();
            txtHelpCounter.Text = string.Empty;
            btnGetValue.IsEnabled = false;
            lstValue.Items.Clear();

            var cat = (PerfMon.Category)lstCategory.SelectedItem;
            string instance = (string)lstInstances.SelectedItem;

            var counters = await LoadingWindow.AwaitResult(this, cat.GetCountersAsync(instance));
            lstCounters.Items.AddRange(counters.OrderBy(it => it.ToString(), StringComparer.Ordinal));

            counterPath.InstanceName = instance;
            counterPath.CounterId = -1;
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private void LstCounters_OnSelected(object sender, RoutedEventArgs e)
        {
            if (lstCounters.SelectedIndex == -1 ||
                lstCounters.SelectedIndex == lastIdxCounter)
                return;

            lastIdxCounter = lstCounters.SelectedIndex;
            var counter = (PerfMon.Counter)lstCounters.SelectedItem;
            txtHelpCounter.Text = counter.Help;

            btnGetValue.IsEnabled = true;
            lstValue.Items.Clear();

            counterPath.CounterName = counter.ToString();
            txtPath.Text = counterPath.GetPath();
            txtZabbixPath.Text = counterPath.GetIdPath();
        }

        private void TxtReadOnly_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void BtnGetValue_OnClick(object sender, RoutedEventArgs e)
        {
            var counter = (PerfMon.Counter)lstCounters.SelectedItem;
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