using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace DispoPlanner.Converters
{
    /// <summary>
    /// Color converter
    /// </summary>
    public class ColorConverter : IValueConverter
    {
        /// <summary>
        /// Convert <see cref="Color"/> into <see cref="SolidColorBrush"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color)
            {
                return new SolidColorBrush((Color)value);
            }
            return null;
        }

        /// <summary>
        /// Convert <see cref="SolidColorBrush"/> into <see cref="Color"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush)
            {
                return ((SolidColorBrush)value).Color;
            }
            return null;
        }
    }
}
