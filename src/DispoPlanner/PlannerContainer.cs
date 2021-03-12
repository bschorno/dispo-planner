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
    /// Represents a container for a planner
    /// </summary>
    public class PlannerContainer : ItemsControl
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerContainer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerContainer), new FrameworkPropertyMetadata(typeof(PlannerContainer)));
        }
    }
}
