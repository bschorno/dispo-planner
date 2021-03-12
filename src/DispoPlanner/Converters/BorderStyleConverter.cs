using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace DispoPlanner.Converters
{
    /// <summary>
    /// Border style converter
    /// </summary>
    public class BorderStyleConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert <see cref="BorderStyle"/> to a border brush
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Length == 0)
                return null;

            Color? borderColor = null;
            if (value.Length >= 2)
            {
                if (value[1] is Color)
                    borderColor = (Color)value[1];
            }

            if (value[0] is BorderStyle)
            {
                Brush borderBrush = BorderAssist.GetBorderBrush((BorderStyle)value[0]);
                if (borderBrush != null)
                {
                    BorderAssist.SetBorderColor(borderBrush, borderColor ?? Color.FromRgb(0, 0, 0));
                    return borderBrush;
                }
            }
            return null;
        }

        /// <summary>
        /// Convert border brush to <see cref="BorderStyle"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
