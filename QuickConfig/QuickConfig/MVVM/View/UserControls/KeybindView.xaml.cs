using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace QuickConfig.MVVM.View.UserControls
{

    public partial class KeybindView : UserControl
    {
        public ObservableCollection<string> MouseButtonList { get; set; }
        public ObservableCollection<string> KeybindList { get; set; }

        public KeybindView()
        {
            InitializeComponent();
            MouseButtonList = new ObservableCollection<string>();
            KeybindList = new ObservableCollection<string>();

            MouseButtonList.Add("Mouse Button 0");
            MouseButtonList.Add("Mouse Button 1");
            MouseButtonList.Add("Mouse Button 2");

            KeybindList.Add("-No keybind set");
            KeybindList.Add("-No keybind set");
            KeybindList.Add("-No keybind set");

            mouseButtonBox.ItemsSource = MouseButtonList;
            keybindBox.ItemsSource = KeybindList;
        }




    }
}
