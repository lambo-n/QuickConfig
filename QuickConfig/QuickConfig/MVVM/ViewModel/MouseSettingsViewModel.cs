using System;
using System.ComponentModel;
using System.Windows.Input;
using WPFAppMouseSettingsHub.BusinessLogic;
using WPFAppMouseSettingsHub.Core;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class MouseSettingsViewModel : INotifyPropertyChanged
    {
        public ICommand SensitivityViewCommand { get; set; }
        public ICommand RGBViewCommand { get; set; }
        public ICommand KeybindViewCommand { get; set; }
        public ICommand MouseSettingsViewCommand { get; set; }
        public ICommand SliderValueChangedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private UserProfileController userProfileController;
        private int _sliderValue;
        private int _dpiDisplay;
        private object _hubCurrentView;

        public MouseSettingsViewModel(MainViewModel mainViewModel)
        {

            SensitivityViewCommand = new RelayCommand(o => ShowSensitivityView());
            RGBViewCommand = new RelayCommand(o => ShowRGBView());
            KeybindViewCommand = new RelayCommand(o => ShowKeybindView());

            MouseSettingsViewCommand = new RelayCommand(o => mainViewModel.ShowUserProfileView());
            SliderValueChangedCommand = new RelayCommand(o => OnSliderValueChanged(_sliderValue));

            _sliderValue = 400;
            DpiDisplay = _sliderValue;

            HubCurrentView = new SensitivityViewModel(this);
        }

        public object HubCurrentView

        {
            get { return _hubCurrentView; }
            set
            {
                _hubCurrentView = value;
                OnPropertyChanged(nameof(HubCurrentView));
            }
        }
        public int DpiDisplay
        {
            get => _dpiDisplay;
            set
            {
                if (_dpiDisplay != value)
                {
                    _dpiDisplay = value;
                    OnPropertyChanged(nameof(DpiDisplay)); // Ensures UI updates
                }
            }
        }
        public int SliderValue
        {
            get { return _sliderValue; }
            set
            {
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    OnPropertyChanged(nameof(SliderValue));
                    OnSliderValueChanged(value); // Optionally handle value changes immediately
                }
            }
        }

        public void ShowSensitivityView()
        {
            HubCurrentView = new SensitivityViewModel(this);
        }
        public void ShowRGBView()
        {
            HubCurrentView = new RGBViewModel(this);
        }
        public void ShowKeybindView()
        {
            HubCurrentView = new KeybindViewModel(this);
        }
        public void OnSliderValueChanged(int newValue)
        {
            DpiDisplay = newValue;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
