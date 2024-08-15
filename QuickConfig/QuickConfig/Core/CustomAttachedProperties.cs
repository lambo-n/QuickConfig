using System.Windows;

namespace QuickConfig.Core
{
    public static class CustomAttachedProperties
    {
        static CustomAttachedProperties()
        {

        }
        public static readonly DependencyProperty HasMouseProperty =
            DependencyProperty.RegisterAttached(
                "HasMouse",
                typeof(bool),
                typeof(CustomAttachedProperties),
                new PropertyMetadata(false)
            );

        public static bool GetHasMouse(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasMouseProperty);
        }

        public static void SetHasMouse(DependencyObject obj, bool value)
        {
            obj.SetValue(HasMouseProperty, value);
        }
    }
}
