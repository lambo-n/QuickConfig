using System.Windows.Input;
using QuickConfig.Core;

namespace QuickConfig.MVVM.ViewModel
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