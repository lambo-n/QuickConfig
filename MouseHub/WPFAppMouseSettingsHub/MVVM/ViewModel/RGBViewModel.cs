using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class RGBViewModel
    {
        public ICommand RGBViewCommand { get; }

        public RGBViewModel(MouseSettingsViewModel hubViewModel)
        {
            RGBViewCommand = new RelayCommand(_ => hubViewModel.ShowRGBView());
        }
    }
}
