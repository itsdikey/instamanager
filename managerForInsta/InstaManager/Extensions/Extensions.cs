using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using HtmlAgilityPack;

namespace InstaManager.Extensions
{
    public static class Extensions
    {
        public static Window GetParentWindow(this DependencyObject child)
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            Window parent = parentObject as Window;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return GetParentWindow(parentObject);
            }
        }

        public static T GetFirstChildOfType<T>(this DependencyObject container) where T : class
        {
            var childCount = VisualTreeHelper.GetChildrenCount(container);

            if (childCount == 0)
                return default(T);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(container, i);
                if (child.GetType() == typeof(T))
                {
                    return child as T;
                }
                else
                {
                    var other = child.GetFirstChildOfType<T>();
                    if (other != null)
                        return other;
                }
            }
            return default(T);
        }
    }
}
