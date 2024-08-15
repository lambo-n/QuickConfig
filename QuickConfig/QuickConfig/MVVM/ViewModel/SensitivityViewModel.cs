using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class SensitivityViewModel
    {
        public ICommand SensitivityViewCommand { get; }

        public SensitivityViewModel(MouseSettingsViewModel mouseSettingsViewModel)
        {
            SensitivityViewCommand = new RelayCommand(_ => mouseSettingsViewModel.ShowSensitivityView());
        }
    }
}
