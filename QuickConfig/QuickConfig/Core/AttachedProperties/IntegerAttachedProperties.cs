using System.Windows;
using System.Windows.Controls;

namespace WPFAppMouseSettingsHub.Core.AttachedProperties
{
    public static class IntegerAttachedProperties
    {
        public static readonly DependencyProperty IntegerProperty =
            DependencyProperty.RegisterAttached("Integer", typeof(int), typeof(IntegerAttachedProperties), new PropertyMetadata(0));

        public static int GetInteger(UIElement element)
        {
            return (int)element.GetValue(IntegerProperty);
        }

        public static void SetInteger(UIElement element, int value)
        {
            element.SetValue(IntegerProperty, value);
        }
    }
}
