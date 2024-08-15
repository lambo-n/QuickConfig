using System.Windows;

namespace WPFAppMouseSettingsHub.MVVM.View.Windows
{
    public partial class MainWindow : Window
    {
        public bool HasMouse { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
