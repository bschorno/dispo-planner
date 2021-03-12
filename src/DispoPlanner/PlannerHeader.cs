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
    /// Represents the header of a <see cref="Planner"/>
    /// </summary>
    public class PlannerHeader : Control
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerHeader), new FrameworkPropertyMetadata(typeof(PlannerHeader)));
        }
    }
}
