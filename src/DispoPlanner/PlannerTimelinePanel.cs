using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Respresents a panel for displaying and arranging <see cref="PlannerAppointmentItem"/>
    /// </summary>
    public class PlannerTimelinePanel : Panel  
    {
        /// <summary>
        /// Static constructor
        /// </summary>
        static PlannerTimelinePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlannerTimelinePanel), new FrameworkPropertyMetadata(typeof(PlannerTimelinePanel)));
        }

        /// <summary>
        /// Calculate datetime from given offset from start
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public DateTime CalculateDateTime(double offset)
        {
            DateTime? Start = PlannerHelper.FindVisualParent<Planner>(this).GetValue(Planner.StartProperty) as DateTime?;
            DateTime? End = PlannerHelper.FindVisualParent<Planner>(this).GetValue(Planner.EndProperty) as DateTime?;
            TimeSpan timeSpan = End.Value.AddHours(1) - Start.Value;

            double minutes = offset / (ActualWidth / timeSpan.TotalMinutes);

            DateTime result = Start.Value.AddMinutes(minutes);
            return new DateTime(result.Year, result.Month, result.Day, result.Hour, result.Minute, 0);
        }

        /// <summary>
        /// Measure override
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size(double.PositiveInfinity, double.PositiveInfinity);

            foreach (UIElement element in this.Children)
            {
                element.Measure(size);
            }

            return new Size();
        }

        /// <summary>
        /// Arrange override 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            double top = 0;
            double left = 0;
            double width = 0;
            double height = 0;

            DateTime? Start = PlannerHelper.FindVisualParent<Planner>(this).GetValue(Planner.StartProperty) as DateTime?;
            DateTime? End = PlannerHelper.FindVisualParent<Planner>(this).GetValue(Planner.EndProperty) as DateTime?;
            TimeSpan timeSpan = End.Value.AddHours(1) - Start.Value;

            foreach (UIElement element in Children)
            {
                DateTime? startTime = element.GetValue(PlannerAppointmentItem.StartProperty) as DateTime?;
                DateTime? endTime = element.GetValue(PlannerAppointmentItem.EndProperty) as DateTime?;

                TimeSpan timeSpanStart = startTime.Value - Start.Value;
                TimeSpan timeSpanEnd = endTime.Value - Start.Value;

                double start_minutes = timeSpanStart.TotalMinutes;
                double end_minutes = timeSpanEnd.TotalMinutes;
                double start_offset = (finalSize.Width / timeSpan.TotalMinutes) * start_minutes;
                double end_offset = (finalSize.Width / timeSpan.TotalMinutes) * end_minutes;

                left = start_offset;
                top = 1;

                height = finalSize.Height - 2;
                width = (end_offset - start_offset);

                element.Arrange(new Rect(left, top, width, height));
                (element as FrameworkElement).Width = width;
            }

            return finalSize;
        }
    }
}
