using ImageIndex;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using System.ComponentModel;
using System.Diagnostics;

namespace ImageSearch.WPF
{
    /// <summary>
    /// Interaction logic for IndexWindows.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        private ICollectionView view;
        private Index index;

        public IndexWindow(Index index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IndexList.ItemsSource = index.IndexDictionary;
            ErrorList.ItemsSource = index.ErrorDictionary;
        }

        private bool Filter(object item)
        {
            KeyValuePair<string, List<string>> kv = (KeyValuePair<string, List<string>>)item;

            return (kv.Key.IndexOf(SearchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            view = CollectionViewSource.GetDefaultView(IndexList.ItemsSource);
            view.Filter = Filter;

            if (IndexList == null) return;
            if (IndexList.ItemsSource == null) return;
            if (string.IsNullOrEmpty(SearchTextBox.Text)) return;

            Stopwatch timer = new Stopwatch();

            timer.Start();
            CollectionViewSource.GetDefaultView(IndexList.ItemsSource).Refresh();
            timer.Stop();

            SearchTimingTextBlock.Text = $"Search time: {timer.Elapsed.TotalSeconds}s";
            SearchTimingTextBlock.Visibility = Visibility.Visible;
            ShowAllButton.Visibility = Visibility.Visible;
            IndexList.SelectedIndex = 0;
        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";

            IndexList.ItemsSource = index.IndexDictionary;

            view = null;

            ShowAllButton.Visibility = Visibility.Collapsed;
            SearchTimingTextBlock.Visibility = Visibility.Collapsed;
            IndexList.SelectedIndex = 0;
        }
    }
}