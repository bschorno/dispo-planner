using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Respresents an appointment container for displaying an appointment
    /// </summary>
    [System.Windows.TemplatePart(Name = "PART_ThumbMove", Type = typeof(System.Windows.Controls.Primitives.Thumb))]
    [System.Windows.TemplatePart(Name = "PART_ThumbLeft", Type = typeof(System.Windows.Controls.Primitives.Thumb))]
    [System.Windows.TemplatePart(Name = "PART_ThumbRight", Type = typeof(System.Windows.Controls.Primitives.Thumb))]
    public class PlannerAppointmentItem : Control
    {
        private Thumb _thumbMove;
        private Thumb _thumbLeft;
        private Thumb _thumbRight;

        private PlannerVirtualAppointmentItem _virtualAppointmentItem;

        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerAppointmentItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerAppointmentItem), new FrameworkPropertyMetadata(typeof(PlannerAppointmentItem)));
        }

        /// <summary>
        /// Identifies the Start dependency property
        /// </summary>
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(DateTime), typeof(PlannerAppointmentItem), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// Gets or sets the start of this item
        /// </summary>
        public DateTime Start
        {
            get { return (DateTime)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        /// <summary>
        /// Identifies the End dependency property
        /// </summary>
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(DateTime), typeof(PlannerAppointmentItem), new PropertyMetadata(default(DateTime)));

        /// <summary>
        /// Gets or sets the end of this item
        /// </summary>
        public DateTime End
        {
            get { return (DateTime)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }

        /// <summary>
        /// Gets called when control template is applied
        /// </summary>
        public override void OnApplyTemplate()
        {
            _thumbMove = GetTemplateChild("PART_ThumbMove") as Thumb;
            _thumbLeft = GetTemplateChild("PART_ThumbLeft") as Thumb;
            _thumbRight = GetTemplateChild("PART_ThumbRight") as Thumb;

            if (_thumbMove != null)
            {
                _thumbMove.DragDelta += OnDragDelta;
                _thumbMove.DragCompleted += OnDragCompleted;
            }
            if (_thumbLeft != null)
            {
                _thumbLeft.DragDelta += OnDragDelta;
                _thumbLeft.DragCompleted += OnDragCompleted;
            }
            if (_thumbRight != null)
            {
                _thumbRight.DragDelta += OnDragDelta;
                _thumbRight.DragCompleted += OnDragCompleted;
            }
        }

        /// <summary>
        /// Event handler on thumb is dragged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender == _thumbMove)
            {
                PlannerTimelinePanel timelinePanel = VisualParent as PlannerTimelinePanel;
                if (timelinePanel != null)
                {
                    if (VisualTreeHelper.HitTest(timelinePanel, Mouse.GetPosition(timelinePanel)) == null)
                    {
                        if (_virtualAppointmentItem == null)
                        {
                            _virtualAppointmentItem = new PlannerVirtualAppointmentItem();
                            _virtualAppointmentItem.DataContext = DataContext;
                        }
                        Planner planner = PlannerHelper.FindVisualParent<Planner>(timelinePanel);
                        planner.PreviewVirtualAppointmentItem(_virtualAppointmentItem);
                    }
                    else
                    {
                        if (_virtualAppointmentItem != null)
                        {
                            Planner planner = PlannerHelper.FindVisualParent<Planner>(timelinePanel);
                            planner.RemoveVirtualAppointmentItem(_virtualAppointmentItem);
                            _virtualAppointmentItem = null;
                        }
                    }
                }

                if (_virtualAppointmentItem != null)
                    _virtualAppointmentItem.Arrange(new Rect(VisualOffset.X + e.HorizontalChange, VisualOffset.Y, ActualWidth, ActualHeight));

                Arrange(new Rect(VisualOffset.X + e.HorizontalChange, VisualOffset.Y, ActualWidth, ActualHeight));
            }
            else if (sender == _thumbLeft)
            {
                double width = ActualWidth - e.HorizontalChange;
                if (width < 10)
                    width = 10;

                Width = width;
                Arrange(new Rect(VisualOffset.X + e.HorizontalChange, VisualOffset.Y, width, ActualHeight));
            }
            else if (sender == _thumbRight)
            {
                double width = ActualWidth + e.HorizontalChange;
                if (width < 10)
                    width = 10;

                Width = width;
                Arrange(new Rect(VisualOffset.X, VisualOffset.Y, width, ActualHeight));
            }

            e.Handled = true;
        }

        /// <summary>
        /// Event handler on thumb drag is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            PlannerTimelinePanel timelinePanel = PlannerHelper.FindVisualParent<PlannerTimelinePanel>(this);
            if (timelinePanel == null)
                return;

            if (sender == _thumbMove)
            {
                TimeSpan timeSpan = End - Start;
                Start = timelinePanel.CalculateDateTime(VisualOffset.X);
                End = Start + timeSpan;

                if (_virtualAppointmentItem != null)
                {
                    IPlannerEntity currentEntity = PlannerHelper.FindVisualParent<PlannerEntity>(this).DataContext as IPlannerEntity;
                    IPlannerEntity targetEntity = PlannerHelper.FindVisualParent<PlannerEntity>(_virtualAppointmentItem).DataContext as IPlannerEntity;
                    IAppointment appointment = DataContext as IAppointment;

                    currentEntity.Appointments.Remove(appointment);
                    targetEntity.Appointments.Add(appointment);

                    Planner planner = PlannerHelper.FindVisualParent<Planner>(timelinePanel);
                    planner.RemoveVirtualAppointmentItem(_virtualAppointmentItem);
                    _virtualAppointmentItem = null;
                }
            }
            else if (sender == _thumbLeft)
            {
                Start = timelinePanel.CalculateDateTime(VisualOffset.X);
            }
            else if (sender == _thumbRight)
            {
                End = timelinePanel.CalculateDateTime(VisualOffset.X + ActualWidth);
            }

            e.Handled = true;
        }
    }
}
