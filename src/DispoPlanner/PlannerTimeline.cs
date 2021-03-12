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
    /// Represents a control to display timeline
    /// </summary>
    public class PlannerTimeline : ItemsControl
    {
        /// <summary>
        /// Static constructors
        /// </summary>
        static PlannerTimeline()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerTimeline), new FrameworkPropertyMetadata(typeof(PlannerTimeline)));
        }

        /// <summary>
        /// Identifies the Start dependency property
        /// </summary>
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(DateTime), typeof(PlannerTimeline), new PropertyMetadata(default(DateTime), (d, e) => ((PlannerTimeline)d).OnStartEndChanged(d, e)));

        /// <summary>
        /// Gets or sets the start of this timeline
        /// </summary>
        public DateTime Start
        {
            get { return (DateTime)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        /// <summary>
        /// Identifies the End dependency property
        /// </summary>
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(DateTime), typeof(PlannerTimeline), new PropertyMetadata(default(DateTime), (d, e) => ((PlannerTimeline)d).OnStartEndChanged(d, e)));

        /// <summary>
        /// Gets or sets the end of this timeline
        /// </summary>
        public DateTime End
        {
            get { return (DateTime)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }

        /// <summary>
        /// Callback on start or end property were changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnStartEndChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            DateTime start = new DateTime(Start.Year, Start.Month, Start.Day, Start.Hour, 0, 0);
            DateTime end = new DateTime(End.Year, End.Month, End.Day, End.Hour, 0, 0);

            ObservableCollection<object> items = new ObservableCollection<object>();

            for (DateTime date = start; date <= end; date = date.AddHours(1))
            {
                items.Add(new { DateTime = date });
            }

            ItemsSource = items;
        }
    }
}
