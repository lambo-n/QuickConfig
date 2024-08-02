using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class UserProfileViewModel
    {
        public ICommand UserProfileViewCommand { get; }

        public UserProfileViewModel(MainViewModel mainViewModel)
        {
            UserProfileViewCommand = new RelayCommand(_ => mainViewModel.ShowMouseHubView());
        }
    }
}



