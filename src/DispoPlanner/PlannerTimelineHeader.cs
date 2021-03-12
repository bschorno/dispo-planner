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
    /// Represents a control for displaying header of the timeline
    /// </summary>
    public class PlannerTimelineHeader : ItemsControl
    {
        /// <summary>
        /// Structure for timeline header data binding
        /// </summary>
        private struct HeaderItem
        {
            public DateTime DateTime { get; set; }
            public bool DisplayDate { get; set; }

            public int ZIndex { get; set; }
        }

        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerTimelineHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerTimelineHeader), new FrameworkPropertyMetadata(typeof(PlannerTimelineHeader)));
        }

        /// <summary>
        /// Identifies the Start dependency property
        /// </summary>
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(DateTime), typeof(PlannerTimelineHeader), new PropertyMetadata(default(DateTime), (d, e) => ((PlannerTimelineHeader)d).OnStartEndChanged(d, e)));

        /// <summary>
        /// Gets or sets the start of the timeline
        /// </summary>
        public DateTime Start
        {
            get { return (DateTime)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        /// <summary>
        /// Identifies the End dependency property
        /// </summary>
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(DateTime), typeof(PlannerTimelineHeader), new PropertyMetadata(default(DateTime), (d, e) => ((PlannerTimelineHeader)d).OnStartEndChanged(d, e)));

        /// <summary>
        /// Gets or sets the end of the timeline
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
            DateTime end   = new DateTime(End.Year, End.Month, End.Day, End.Hour, 0, 0);

            ObservableCollection<HeaderItem> items = new ObservableCollection<HeaderItem>();
            HeaderItem? item = null;

            int zIndex = int.MaxValue;
            for (DateTime date = start; date <= end; date = date.AddHours(1))
            {
                item = new HeaderItem()
                {
                    DateTime = date,
                    DisplayDate = item == null || item.Value.DateTime.Date != date.Date,
                    ZIndex = zIndex--
                };
                items.Add(item.Value);
            }

            ItemsSource = items;
        }
    }
}
