﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shell;

namespace PerfMonExplorer.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private int lastIdxCategory = -1;
    private int lastIdxInstance = -1;
    private int lastIdxCounter = -1;

    private CounterPath counterPath;

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
            lstCategory.SelectedIndex == lastIdxCategory)
            return;

        SetLoadingStatus(true);
        lastIdxCategory = lstCategory.SelectedIndex;
        lastIdxInstance = -1;
        lastIdxCounter = -1;
        lstInstances.Items.Clear();
        lstCounters.Items.Clear();
        txtHelpCounter.Text = string.Empty;
        btnGetValue.IsEnabled = false;
        lstValue.Items.Clear();

        var cat = (Category)lstCategory.SelectedItem;

        var instances = await cat.GetInstancesNamesAsync();
        lstInstances.Items.AddRange(instances.OrderBy(static it => it, StringComparer.Ordinal));
        txtHelpCategory.Text = cat.Help;

        if (lstInstances.Items.Count == 0)
        {
            var counters = await cat.GetCountersAsync(null);
            lstCounters.Items.AddRange(counters.OrderBy(static it => it.ToString(), StringComparer.Ordinal));
        }

        counterPath = new CounterPath();
        counterPath.CategoryName = cat.ToString();
        txtPath.Text = counterPath.GetPath();
        txtZabbixPath.Text = counterPath.GetIdPath();
        SetLoadingStatus(false);
    }

    private async void LstInstances_OnSelected(object sender, RoutedEventArgs e)
    {
        if (lstInstances.SelectedIndex == -1 ||
            lstInstances.SelectedIndex == lastIdxInstance)
            return;

        SetLoadingStatus(true);
        lastIdxInstance = lstInstances.SelectedIndex;
        lastIdxCounter = -1;
        lstCounters.Items.Clear();
        txtHelpCounter.Text = string.Empty;
        btnGetValue.IsEnabled = false;
        lstValue.Items.Clear();

        var cat = (Category)lstCategory.SelectedItem;
        string instance = (string)lstInstances.SelectedItem;

        var counters = await cat.GetCountersAsync(instance);
        lstCounters.Items.AddRange(counters.OrderBy(static it => it.ToString(), StringComparer.Ordinal));

        counterPath.InstanceName = instance;
        counterPath.CounterId = -1;
        txtPath.Text = counterPath.GetPath();
        txtZabbixPath.Text = counterPath.GetIdPath();
        SetLoadingStatus(false);
    }

    private void LstCounters_OnSelected(object sender, RoutedEventArgs e)
    {
        if (lstCounters.SelectedIndex == -1 ||
            lstCounters.SelectedIndex == lastIdxCounter)
            return;

        lastIdxCounter = lstCounters.SelectedIndex;
        var counter = (Counter)lstCounters.SelectedItem;
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