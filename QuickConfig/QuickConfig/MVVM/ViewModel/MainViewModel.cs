using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;
using WPFAppMouseSettingsHub.MVVM.Model;
using WPFAppMouseSettingsHub.MVVM.View.Windows;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ModelFacade _modelFacade { get; set; }
        public ICommand UserProfileViewCommand { get; set; }
        public ICommand WelcomeViewCommand { get; set; }
        public ICommand MouseSettingsViewCommand { get; set; }
        public ICommand CreateUserProfileCommand { get; set; }
        public ICommand AddNewMouseCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private WelcomeViewModel _welcomeViewModel;
        private UserProfileViewModel _userProfileViewModel;
        private MouseSettingsViewModel _mouseSettingsViewModel;
        private List<IUserProfile> _userProfileList;
        private List<IMouse> _availableMouseToAddList;
        private List<string> _availableMouseToAddListName;
        private IMouse _currentSelectedAvailableMouse;
        private object _mainCurrentView;
        private string _newProfileName;
        private string _currentSelectedUserProfileName;
        private bool _hasMouseButton1;
        private bool _hasMouseButton2;
        private bool _hasMouseButton3;
        private int _currentSelectedUserProfileIndex;
        private int _currentSelectedAvailableMouseIndex;
        private string _currentSelectedAvailableMouseName;

        public object MainCurrentView
        {
            get { return _mainCurrentView; }
            set
            {
                _mainCurrentView = value;
                OnPropertyChanged(nameof(MainCurrentView));
            }
        }
        public List<IMouse> AvailableMouseList
        {
            get { return _availableMouseToAddList; }
            set
            {
                if (_availableMouseToAddList != value)
                {
                    _availableMouseToAddList = value;
                    OnPropertyChanged(nameof(AvailableMouseList));
                }
            }
        }
        public List<string> AvailableMouseNameList
        {
            get { return _availableMouseToAddListName; }
            set
            {
                if (_availableMouseToAddListName != value)
                {
                    _availableMouseToAddListName = value;
                    OnPropertyChanged(nameof(AvailableMouseNameList));
                }
            }
        }
        public string NewProfileName
        {
            get { return _newProfileName; }
            set
            {
                if (_newProfileName != value)
                {
                    _newProfileName = value;
                    OnPropertyChanged(nameof(NewProfileName));
                }
            }
        }
        public string CurrentSelectedUserProfileName
        {
            get 
            { 
                return _currentSelectedUserProfileName; 
            }
            set
            {
                if (_currentSelectedUserProfileName != value)
                {
                    _currentSelectedUserProfileName = value;
                    OnPropertyChanged(nameof(CurrentSelectedUserProfileName));

                }
            }
            
        }
        
        public int CurrentSelectedAvailableMouseIndex
        {
            get { return _currentSelectedAvailableMouseIndex; }
            set
            {
                if (_currentSelectedAvailableMouseIndex != value)
                {
                    _currentSelectedAvailableMouseIndex = value;
                    OnPropertyChanged(nameof(CurrentSelectedAvailableMouseIndex));
                }
            }
        }
        public string CurrentSelectedAvailableMouseName
        {
            get { return _currentSelectedAvailableMouseName; }
            set
            {
                if (_currentSelectedAvailableMouseName != value)
                {
                    _currentSelectedAvailableMouseName = value;
                    OnPropertyChanged(nameof(CurrentSelectedAvailableMouseName));
                }
            }
        }
        public IMouse CurrentSelectedAvailableMouse
        {
            get { return _currentSelectedAvailableMouse; }
            set
            {
                if (_currentSelectedAvailableMouse != value)
                {
                    _currentSelectedAvailableMouse = value;
                    OnPropertyChanged(nameof(_currentSelectedAvailableMouse));
                }
            }
        }
        public MainViewModel()
        {
         

            _modelFacade = new ModelFacade();
           

            _userProfileList = _modelFacade.userProfileController.GetUserProfileList();
            CurrentSelectedAvailableMouseIndex = 0;
            AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(_userProfileList[CurrentSelectedAvailableMouseIndex]);
            AvailableMouseNameList = new List<string>();

            _welcomeViewModel = new WelcomeViewModel(this);
            _userProfileViewModel = new UserProfileViewModel(this);
            _mouseSettingsViewModel = new MouseSettingsViewModel(this);

            MainCurrentView = new WelcomeViewModel(this);

            CreateUserProfileCommand = new RelayCommand(CreateProfileButtonHandler);
            MouseSettingsViewCommand = new RelayCommand(o => ShowUserProfileView());
            AddNewMouseCommand = new RelayCommand(AddNewMouseButtonHandler);

            NewProfileName = "";
            SetAvailableMouseNameList();
        }

        public void CreateProfileButtonHandler(object parameter)
        {
            Console.WriteLine($"HANDLED {NewProfileName}");
            if (parameter is Window window)
            {
                window.Close();
            }
        }
        public void AddNewMouseButtonHandler(object parameter)
        {
            Console.WriteLine(AvailableMouseList.Count());

            if (parameter is Window window)
            {
                window.Close();
            }
        }
        public void AddNewMouse()
        {
            CurrentSelectedAvailableMouse = _availableMouseToAddList[CurrentSelectedAvailableMouseIndex];
        }
        public void ShowWelcomeView()
        {
            MainCurrentView = _welcomeViewModel;
        }
        public void ShowUserProfileView()
        {
            MainCurrentView = _userProfileViewModel;
        }
        public void ShowMouseHubView()
        {
            MainCurrentView = _mouseSettingsViewModel;
        }
        public void ShowAddProfilePopup()
        {
            AddProfileWindow addProfilePopup = new AddProfileWindow
            {
                DataContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).MainViewModel
            };
            addProfilePopup.ShowDialog();
        }
        public void ShowAddMousePopup()
        {
            AddMouseWindow addMouseWindow = new AddMouseWindow
            {
                DataContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).MainViewModel
            };
            addMouseWindow.ShowDialog();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SetAvailableMouseNameList()
        {
            AvailableMouseNameList.Clear();
            foreach (IMouse mouse in AvailableMouseList)
            {
                AvailableMouseNameList.Add(_modelFacade.mouseController.GetMouseModelName(mouse));
            }
        }
    }
}
