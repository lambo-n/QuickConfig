using System.Windows.Input;
using QuickConfig.Core;

namespace QuickConfig.MVVM.ViewModel
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
