using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DispoPlanner
{
    /// <summary>
    /// Represents a style for <see cref="IAppointment"/> 
    /// Provides some predefined styles, can be used to create own styles
    /// </summary>
    public class AppointmentStyle
    {
        /// <summary>
        /// Default appointment style light
        /// </summary>
        public static AppointmentStyle StyleColorLight = new AppointmentStyle()
        {
            BackgroundColor = Color.FromRgb(191, 228, 255),
            BorderColor = Color.FromRgb(116, 116, 116),
            BorderThickness = new Thickness(1.0d),
            BorderStyle = BorderStyle.Dotted
        };

        /// <summary>
        /// Default appointment style medium
        /// </summary>
        public static AppointmentStyle StyleColorMid = new AppointmentStyle()
        {
            BackgroundColor = Color.FromRgb(76, 174, 247),
            BorderColor = Color.FromRgb(116, 116, 116),
            BorderThickness = new Thickness(1.0d),
            BorderStyle = BorderStyle.Solid
        };

        /// <summary>
        /// Default appointment style dark
        /// </summary>
        public static AppointmentStyle StyleColorDark = new AppointmentStyle()
        {
            BackgroundColor = Color.FromRgb(6, 142, 244),
            BorderColor = Color.FromRgb(116, 116, 116),
            BorderThickness = new Thickness(1.0d),
            BorderStyle = BorderStyle.Solid
        };

        /// <summary>
        /// Background color
        /// </summary>
        public Color BackgroundColor
        {
            get; 
            set;
        }

        /// <summary>
        /// Border color
        /// </summary>
        public Color BorderColor
        {
            get;
            set;
        }

        /// <summary>
        /// Border thickness
        /// </summary>
        public Thickness BorderThickness
        {
            get;
            set;
        }

        /// <summary>
        /// Border style
        /// </summary>
        public BorderStyle BorderStyle
        {
            get;
            set;
        }

        /// <summary>
        /// Crate new instance of <see cref="AppointmentStyle"/>
        /// </summary>
        public AppointmentStyle()
        {
            
        }
    }
}
