using System.Windows.Input;
using QuickConfig.Core;

namespace QuickConfig.MVVM.ViewModel
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
