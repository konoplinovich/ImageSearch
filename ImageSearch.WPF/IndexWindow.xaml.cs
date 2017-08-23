using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageSearch.WPF
{
    /// <summary>
    /// Interaction logic for IndexWindows.xaml
    /// </summary>
    public partial class IndexWindow : Window
    {
        public IndexWindow(Dictionary<string, List<string>> index)
        {
            InitializeComponent();

            Dictionary<string, string> flatIndex = new Dictionary<string, string>();

            foreach (var item in index)
            {
                string flat = "";



                flatIndex[item.Key] = flat;
            }

            IndexList.ItemsSource = flatIndex;
        }
    }
}
