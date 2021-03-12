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
    /// Respresents a items control which displays appointments 
    /// </summary>
    public class PlannerAppointment : ItemsControl
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerAppointment()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerAppointment), new FrameworkPropertyMetadata(typeof(PlannerAppointment)));
        }

        /// <summary>
        /// Get container for items
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new PlannerAppointmentItem();
        }

        /// <summary>
        /// Check if items is its own container
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is PlannerAppointmentItem);
        }
    }
}
