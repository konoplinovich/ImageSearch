using ImageIndex;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace ImageSearch.WPF
{
    /// <summary>
    /// Interaction logic for IndexWindows.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        private Index index;
        private int count;

        public IndexWindow(Index index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IndexList.ItemsSource = index.IndexDictionary;
            ErrorList.ItemsSource = index.ErrorDictionary;

            count = index.IndexDictionary.Count;
            CountLabel.Content = count;
        }

        private bool Filter(object item)
        {
            KeyValuePair<string, List<string>> kv = (KeyValuePair<string, List<string>>)item;

            return (kv.Key.IndexOf(SearchTextBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void SearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            IndexList.Items.Filter = Filter;
            timer.Stop();

            int searchCount = IndexList.Items.Count;
            
            if (count != searchCount)
            {
                SearchTimingTextBlock.Text = $"Search time: {timer.Elapsed.TotalSeconds}s ({searchCount} records from {count})";
                SearchTimingTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                SearchTimingTextBlock.Visibility = Visibility.Collapsed;
            }

            IndexList.SelectedIndex = 0;
        }
    }
}