using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
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
    /// Represents a control for planning multiple ressources (Entities) in a timeline like calendar
    /// </summary>
    public class Planner : Control
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static Planner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Planner), new FrameworkPropertyMetadata(typeof(Planner)));
        }

        /// <summary>
        /// Create new instance of <see cref="Planer"/>
        /// </summary>
        public Planner()
            : base()
        {
            SetValue(EntityGroupsProperty, new ObservableCollection<PlannerEntityGroup>());
        }

        /// <summary>
        /// Identifies the EntityGroups dependency property
        /// </summary>
        public static readonly DependencyProperty EntityGroupsProperty = DependencyProperty.Register("EntityGroups", typeof(ObservableCollection<PlannerEntityGroup>), typeof(Planner), new PropertyMetadata(default(ObservableCollection<PlannerEntityGroup>)));

        /// <summary>
        /// Gets or sets the entity groups
        /// </summary>
        public ObservableCollection<PlannerEntityGroup> EntityGroups
        {
            get { return (ObservableCollection<PlannerEntityGroup>)GetValue(EntityGroupsProperty); }
            set { SetValue(EntityGroupsProperty, value); }
        }

        /// <summary>
        /// Identifies the EntityTemplate dependency property
        /// </summary>
        public static readonly DependencyProperty EntityTemplateProperty = DependencyProperty.Register("EntityTemplate", typeof(DataTemplate), typeof(Planner));

        /// <summary>
        /// Gets or sets the data template for <see cref="Entities"/>
        /// </summary>
        public DataTemplate EntityTemplate
        {
            get { return (DataTemplate)GetValue(EntityTemplateProperty); }
            set { SetValue(EntityTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies the Header dependency property
        /// </summary>
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(Control), typeof(Planner));

        /// <summary>
        /// Gets or sets the header control
        /// </summary>
        public Control Header
        {
            get { return (Control)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        /// <summary>
        /// Identifies the Start dependency property
        /// </summary>
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(DateTime), typeof(Planner), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// Gets or sets the start date/time on which the planner will start
        /// </summary>
        public DateTime Start
        {
            get { return (DateTime)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
        
        /// <summary>
        /// Identifies the End dependency property
        /// </summary>
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(DateTime), typeof(Planner), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// Gets or sets the end date/time on which the planner will start
        /// </summary>
        public DateTime End
        {
            get { return (DateTime)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }

        /// <summary>
        /// Identifies the Title dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Planner), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the planner title
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Preview virtual appointment item on a virtual panel
        /// </summary>
        /// <param name="appointmentItem"></param>
        public void PreviewVirtualAppointmentItem(PlannerAppointmentItem appointmentItem)
        {
            PlannerEntity targetEntity = PlannerHelper.FindVisualChild<PlannerEntity>(this).Find(_ => VisualTreeHelper.HitTest(_, Mouse.GetPosition(_)) != null);
            if (targetEntity != null)
            {
                if (appointmentItem.Parent != null)
                {
                    if (appointmentItem.Parent == targetEntity.GetVirtualPanel())
                        return;
                    PlannerTimelinePanel currentPanel = appointmentItem.Parent as PlannerTimelinePanel;
                    currentPanel.Children.Remove(appointmentItem);
                }

                PlannerTimelinePanel virtualPanel = targetEntity.GetVirtualPanel();
                virtualPanel.Children.Add(appointmentItem);
            }
        }

        /// <summary>
        /// Remove virtual appointment item from it's parent panel
        /// </summary>
        /// <param name="appointmentItem"></param>
        public void RemoveVirtualAppointmentItem(PlannerAppointmentItem appointmentItem)
        {
            if (appointmentItem == null)
                return;
            PlannerTimelinePanel panel = appointmentItem.Parent as PlannerTimelinePanel;
            if (panel != null)
            {
                panel.Children.Remove(appointmentItem);
            }
        }
    }
}
