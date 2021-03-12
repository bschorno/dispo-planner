using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace DispoPlanner
{
    /// <summary>
    /// Helper functions <see cref="Planner"/> control
    /// </summary>
    public static class PlannerHelper
    {
        /// <summary>
        /// Find parent of specific type <typeparamref name="T"/> of an <see cref="UIElement"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }

        /// <summary>
        /// Find childs of specific types <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<T> FindVisualChild<T>(UIElement element) where T : UIElement
        {
            List<T> childrens = new List<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                UIElement child = VisualTreeHelper.GetChild(element, i) as UIElement;
                if (child == null)
                    continue;
                T correctlyTyped = child as T;
                if (correctlyTyped != null)
                {
                    childrens.Add(correctlyTyped);
                }
                else
                {
                    childrens.AddRange(FindVisualChild<T>(child));
                }
            }

            return childrens;
        }
    }
}
