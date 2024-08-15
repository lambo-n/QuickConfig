using System.Windows.Input;
using QuickConfig.Core;

namespace QuickConfig.MVVM.ViewModel
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
