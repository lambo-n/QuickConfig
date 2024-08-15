using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class WelcomeViewModel
    {
        public ICommand WelcomeViewCommand { get; }

        public WelcomeViewModel(MainViewModel mainViewModel)
        {
            WelcomeViewCommand = new RelayCommand(_ => mainViewModel.ShowUserProfileView());
        }
    }
}