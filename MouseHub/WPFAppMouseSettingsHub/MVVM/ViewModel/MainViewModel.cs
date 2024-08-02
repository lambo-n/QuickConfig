using System.ComponentModel;
using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ICommand UserProfileViewCommand { get; set; }
        public ICommand WelcomeViewCommand { get; set; }
        public ICommand MouseHubViewCommand { get; set; }

        private object _mainCurrentView;
        private bool _hasMouse;

        public MainViewModel()
        {
            WelcomeViewCommand = new RelayCommand(o => ShowWelcomeView());
            UserProfileViewCommand = new RelayCommand(o => ShowUserProfileView());
            MouseHubViewCommand = new RelayCommand(o => ShowMouseHubView());

            MainCurrentView = new WelcomeViewModel(this);
        }
        public object MainCurrentView

        {
            get { return _mainCurrentView; }
            set
            {
                _mainCurrentView = value;
                OnPropertyChanged(nameof(MainCurrentView));
            }
        }
        public bool HasMouse
        {
            get => _hasMouse;
            set
            {
                if (_hasMouse != value)
                {
                    _hasMouse = value;
                    OnPropertyChanged(nameof(HasMouse));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowWelcomeView()
        {
            MainCurrentView = new WelcomeViewModel(this);
        }

        public void ShowUserProfileView()
        {
            MainCurrentView = new UserProfileViewModel(this);
        }

        public void ShowMouseHubView()
        {
            MainCurrentView = new MouseSettingsViewModel(this);
        }


    }
}
