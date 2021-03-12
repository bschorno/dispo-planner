using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DispoPlanner
{
    /// <summary>
    /// Represents a single frame in <see cref="PlannerTimelineHeader"/>
    /// </summary>
    [System.Windows.TemplatePart(Name = "PART_DateLabel", Type = typeof(System.Windows.Controls.TextBlock))]
    
    public class PlannerTimelineHeaderItem : Control
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerTimelineHeaderItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerTimelineHeaderItem), new FrameworkPropertyMetadata(typeof(PlannerTimelineHeaderItem)));
        }

        /// <summary>
        /// Identifies the DateTime dependency property
        /// </summary>
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register("DateTime", typeof(DateTime), typeof(PlannerTimelineHeaderItem), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// Gets or sets datetime of this control
        /// </summary>
        public DateTime DateTime
        {
            get { return (DateTime)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        /// <summary>
        /// Identifies the DisplayDate dependency property
        /// </summary>
        public static readonly DependencyProperty DisplayDateProperty = DependencyProperty.Register("DisplayDate", typeof(bool), typeof(PlannerTimelineHeaderItem), new PropertyMetadata(false));

        /// <summary>
        /// Gets or sets value that indicates whether the date should be displayed along with the time
        /// </summary>
        public bool DisplayDate
        {
            get { return (bool)GetValue(DisplayDateProperty); }
            set { SetValue(DisplayDateProperty, value); }
        }
    }
}
