using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
