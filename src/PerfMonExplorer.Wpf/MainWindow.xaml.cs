using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;

namespace PerfMonExplorer.Wpf;

public partial class MainWindow
{
    private int _lastIdxCategory = -1;
    private int _lastIdxInstance = -1;
    private int _lastIdxCounter = -1;

    private CounterPath _counterPath;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void MainWindow_OnLoaded(object sender, EventArgs e)
    {
        var categories = await Category.GetCategoriesAsync();
        SetLoadingStatus(false);
        lstCategory.Items.AddRange(categories.OrderBy(it => it.ToString(), StringComparer.Ordinal));
    }

    private async void LstCategory_OnSelected(object sender, RoutedEventArgs e)
    {
        if (lstCategory.SelectedIndex == -1 ||
            lstCategory.SelectedIndex == _lastIdxCategory)
            return;

        SetLoadingStatus(true);
        _lastIdxCategory = lstCategory.SelectedIndex;
        _lastIdxInstance = -1;
        _lastIdxCounter = -1;
        lstInstances.Items.Clear();
        lstCounters.Items.Clear();
        txtHelpCounter.Text = string.Empty;
        btnGetValue.IsEnabled = false;
        lstValue.Items.Clear();

        var cat = (Category)lstCategory.SelectedItem;

        var instances = await cat.GetInstancesNamesAsync();
        lstInstances.Items.AddRange(instances.OrderBy(static it => it, StringComparer.Ordinal));
        txtHelpCategory.Text = cat.Help.IfFail(string.Empty);

        if (lstInstances.Items.Count == 0)
        {
            var counters = await cat.GetCountersAsync(null);
            lstCounters.Items.AddRange(counters.OrderBy(static it => it.ToString(), StringComparer.Ordinal));
        }

        _counterPath = new CounterPath();
        _counterPath.CategoryName = cat.ToString();
        txtPath.Text = _counterPath.GetPath();
        txtZabbixPath.Text = _counterPath.GetIdPath();
        SetLoadingStatus(false);
    }

    private async void LstInstances_OnSelected(object sender, RoutedEventArgs e)
    {
        if (lstInstances.SelectedIndex == -1 ||
            lstInstances.SelectedIndex == _lastIdxInstance)
            return;

        SetLoadingStatus(true);
        _lastIdxInstance = lstInstances.SelectedIndex;
        _lastIdxCounter = -1;
        lstCounters.Items.Clear();
        txtHelpCounter.Text = string.Empty;
        btnGetValue.IsEnabled = false;
        lstValue.Items.Clear();

        var cat = (Category)lstCategory.SelectedItem;
        string instance = (string)lstInstances.SelectedItem;

        var counters = await cat.GetCountersAsync(instance);
        lstCounters.Items.AddRange(counters.OrderBy(static it => it.ToString(), StringComparer.Ordinal));

        _counterPath.InstanceName = instance;
        _counterPath.CounterId = -1;
        txtPath.Text = _counterPath.GetPath();
        txtZabbixPath.Text = _counterPath.GetIdPath();
        SetLoadingStatus(false);
    }

    private void LstCounters_OnSelected(object sender, RoutedEventArgs e)
    {
        if (lstCounters.SelectedIndex == -1 ||
            lstCounters.SelectedIndex == _lastIdxCounter)
            return;

        _lastIdxCounter = lstCounters.SelectedIndex;
        var counter = (Counter)lstCounters.SelectedItem;
        txtHelpCounter.Text = counter.Help.IfFail(string.Empty);

        btnGetValue.IsEnabled = true;
        lstValue.Items.Clear();

        _counterPath.CounterName = counter.ToString();
        txtPath.Text = _counterPath.GetPath();
        txtZabbixPath.Text = _counterPath.GetIdPath();
    }

    private void TxtReadOnly_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ((TextBox)sender).SelectAll();
    }

    private void BtnGetValue_OnClick(object sender, RoutedEventArgs e)
    {
        var counter = (Counter)lstCounters.SelectedItem;
        float nValue = float.NaN;
        long rValue = long.MinValue;

        try { nValue = counter.NextValue(); }
        catch { /* Ignore exceptions */ }
        try { rValue = counter.RawValue; }
        catch { /* Ignore exceptions */ }

        var item = string.Format("{0} (Raw: {1})",
            nValue.ToString(CultureInfo.InvariantCulture),
            rValue == long.MinValue ? "NaN" : rValue.ToString(CultureInfo.InvariantCulture));
        lstValue.Items.Insert(0, item);
    }

    private void SetLoadingStatus(bool isLoading)
    {
        if (isLoading)
        {
            IsEnabled = false;
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Indeterminate;
            LoadingProgressBar.Visibility = Visibility.Visible;
        }
        else
        {
            IsEnabled = true;
            TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            LoadingProgressBar.Visibility = Visibility.Hidden;
        }
    }
}