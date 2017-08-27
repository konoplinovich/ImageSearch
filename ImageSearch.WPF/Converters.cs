using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ImageSearch.WPF
{
    [ValueConversion(typeof(KeyValuePair<string, List<string>>), typeof(Brush))]
    public class KeysCountToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            KeyValuePair<string, List<string>> item = (KeyValuePair<string, List<string>>)value;

            if (item.Value.Count == 2) return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AABEFF4B"));
            if (item.Value.Count == 3) return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AA74FF00"));
            if (item.Value.Count == 4) return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AAFFC500"));
            if (item.Value.Count == 5) return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AAF54300"));
            if (item.Value.Count >= 6) return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AAFF0000"));
            else return new SolidColorBrush((Color)ColorConverter.ConvertFromString("White"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(KeyValuePair<string, List<string>>), typeof(string))]
    public class ItemToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";

            KeyValuePair<string, List<string>> item = (KeyValuePair<string, List<string>>)value;

            string flat = "";

            for (int i = 0; i < item.Value.Count; i++)
            {
                flat += item.Value[i] + Environment.NewLine; 
            }

            if (item.Value.Count > 1) flat += Environment.NewLine + $"Total: {item.Value.Count}";

            return flat;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(KeyValuePair<string, List<string>>), typeof(string))]
    public class KeysCountToLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "Keywords:";

            KeyValuePair<string, List<string>> item = (KeyValuePair<string, List<string>>)value;

            if (item.Value.Count == 1) return "Keyword:";
            else return "Keywords:";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
