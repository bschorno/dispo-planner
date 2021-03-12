using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Represents a control for displaying <see cref="IPlannerEntity"/>
    /// </summary>
    [System.Windows.TemplatePart(Name = "PART_VirtualPanel", Type = typeof(PlannerTimelinePanel))]
    public class PlannerEntity : ContentControl
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerEntity()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerEntity), new FrameworkPropertyMetadata(typeof(PlannerEntity)));
        }

        /// <summary>
        /// Identifies the Appointments dependency property
        /// </summary>
        public static readonly DependencyProperty AppointmentsProperty = DependencyProperty.Register("Appointments", typeof(IEnumerable<IAppointment>), typeof(PlannerEntity), new PropertyMetadata(default(ObservableCollection<IAppointment>)));

        /// <summary>
        /// Gets or sets the appointments
        /// </summary>
        public IEnumerable<IAppointment> Appointments
        {
            get { return (ObservableCollection<IAppointment>)GetValue(AppointmentsProperty); }
            set { SetValue(AppointmentsProperty, value); }
        }

        /// <summary>
        /// Get virtual planner panel
        /// </summary>
        /// <returns></returns>
        public PlannerTimelinePanel GetVirtualPanel()
        {
            return GetTemplateChild("PART_VirtualPanel") as PlannerTimelinePanel;
        }
    }
}
