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
    /// Represents a single frame in <see cref="PlannerTimeline"/>
    /// </summary>
    public class PlannerTimelineItem : Control
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerTimelineItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerTimelineItem), new FrameworkPropertyMetadata(typeof(PlannerTimelineItem)));
        }
    }
}
