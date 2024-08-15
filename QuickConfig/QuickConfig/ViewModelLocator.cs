using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;
using WPFAppMouseSettingsHub.MVVM.Model;
using WPFAppMouseSettingsHub.MVVM.ViewModel;

namespace WPFAppMouseSettingsHub
{
    public class ViewModelLocator
    {

        private static MainViewModel _mainViewModel = new MainViewModel();
        public WelcomeViewModel WelcomeViewModel => new WelcomeViewModel(MainViewModel);
        public UserProfileViewModel UserProfileViewModel => new UserProfileViewModel(MainViewModel);
        public MouseSettingsViewModel MouseSettingsViewModel => new MouseSettingsViewModel(MainViewModel);
        public SensitivityViewModel SensitivityViewModel => new SensitivityViewModel(MouseSettingsViewModel);
        public RGBViewModel RGBViewModel => new RGBViewModel(MouseSettingsViewModel);
        public KeybindViewModel KeybindViewModel => new KeybindViewModel(MouseSettingsViewModel);
        public MainViewModel MainViewModel
        {
            get { return _mainViewModel; }
        }
    }
}
