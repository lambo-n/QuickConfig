using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class KeybindViewModel
    {
        public ICommand KeybindViewCommand { get; }

        public KeybindViewModel(MouseSettingsViewModel hubViewModel)
        {
            KeybindViewCommand = new RelayCommand(o => hubViewModel.ShowKeybindView());
        }
    }
}
