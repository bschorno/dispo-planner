using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DispoPlanner
{
    /// <summary>
    /// Helper class for border styles
    /// </summary>
    public static class BorderAssist
    {
        private static readonly IDictionary<BorderStyle, Brush> BorderBrushes;

        /// <summary>
        /// Static constructor
        /// </summary>
        static BorderAssist()
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary() { Source = new Uri("pack://application:,,,/DispoPlanner;component/Themes/BorderBrush.xaml") };
            BorderBrushes = new Dictionary<BorderStyle, Brush>()
            {
                { BorderStyle.Solid, (SolidColorBrush)resourceDictionary["BorderBrushSolid"] },
                { BorderStyle.Dotted, (DrawingBrush)resourceDictionary["BorderBrushDotted"] }
            };
        }

        /// <summary>
        /// Identifies the BorderColor attached dependency property
        /// </summary>
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.RegisterAttached("BorderColor", typeof(Color), typeof(BorderAssist));

        /// <summary>
        /// Sets the boder color
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="value"></param>
        public static void SetBorderColor(DependencyObject dependencyObject, Color value)
        {
            dependencyObject.SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// Gets the border color
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static Color GetBorderColor(DependencyObject dependencyObject)
        {
            return (Color)dependencyObject.GetValue(BorderColorProperty);
        }

        /// <summary>
        /// Get border brush
        /// </summary>
        /// <param name="style"></param>
        public static Brush GetBorderBrush(BorderStyle style)
        {
            Brush brush;
            BorderBrushes.TryGetValue(style, out brush);
            return brush;
        }
    }
}
