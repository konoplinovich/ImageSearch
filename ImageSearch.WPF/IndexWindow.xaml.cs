using ImageIndex;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ImageSearch.WPF
{
    /// <summary>
    /// Interaction logic for IndexWindows.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow(Index index)
        {
            InitializeComponent();

            Dictionary<string, string> flatIndex = new Dictionary<string, string>();

            foreach (var item in index.IndexDictionary)
            {
                string flat = "";

                for (int i = 0; i < item.Value.Count; i++)
                {
                    flat += item.Value[i];
                    if (i != item.Value.Count - 1) flat += Environment.NewLine;
                }

                flatIndex[item.Key] = flat;
            }

            IndexList.ItemsSource = flatIndex;
            ErrorList.ItemsSource = index.ErrorDictionary;
        }
    }
}
