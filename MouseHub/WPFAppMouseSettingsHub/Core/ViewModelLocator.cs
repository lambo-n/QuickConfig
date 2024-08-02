using WPFAppMouseSettingsHub.MVVM.ViewModel;

namespace WPFAppMouseSettingsHub.Core
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => new MainViewModel();
        public WelcomeViewModel WelcomeViewModel => new WelcomeViewModel(MainViewModel);
        public UserProfileViewModel UserProfileViewModel => new UserProfileViewModel(MainViewModel);
        public MouseSettingsViewModel MouseSettingsViewModel => new MouseSettingsViewModel(MainViewModel);
        public SensitivityViewModel SensitivityViewModel => new SensitivityViewModel(MouseSettingsViewModel);
        public RGBViewModel RGBViewModel => new RGBViewModel(MouseSettingsViewModel);
        public KeybindViewModel KeybindViewModel => new KeybindViewModel(MouseSettingsViewModel);
        

    }
}
