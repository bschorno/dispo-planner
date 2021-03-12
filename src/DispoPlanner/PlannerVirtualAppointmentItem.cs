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
    /// Represents an virtual appointment which appears when an <see cref="PlannerAppointmentItem"/> get's switcht between <see cref="PlannerEntity"/>
    /// </summary>
    public class PlannerVirtualAppointmentItem : PlannerAppointmentItem
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerVirtualAppointmentItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerVirtualAppointmentItem), new FrameworkPropertyMetadata(typeof(PlannerVirtualAppointmentItem)));
        }
    }
}
