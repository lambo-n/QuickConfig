using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;
using WPFAppMouseSettingsHub.DataAccess.ObjectModels;
using WPFAppMouseSettingsHub.MVVM.Model;
using WPFAppMouseSettingsHub.MVVM.View.Windows;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class UserProfileViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonMouseContainerCommand { get; set; }
        public ICommand AddNewUserProfileCommand { get; set; }
        public ICommand AddNewMouseCommand { get; set; }
        public ICommand DeleteCurrentProfileCommand { get; set; }
        public ICommand UpdateCommand {  get; set; }
        public IMouse ChosenMouse { get; set; }


        private MainViewModel _mainViewModel;
        private ModelFacade _modelFacade;
        private List<IUserProfile> _userProfileList;
        private List<IMouse> _connectedMouseList;
        private ObservableCollection<string> _userProfileNameList;
        public event PropertyChangedEventHandler PropertyChanged;
        private IMouse _connectedMouse1;
        private IMouse _connectedMouse2;
        private IMouse _connectedMouse3;
        private IUserProfile _currentSelectedUserProfile;
        private string _mouseContainerButtonName1;
        private string _mouseContainerButtonName2;
        private string _mouseContainerButtonName3;
        private bool _hasMouse1;
        private bool _hasMouse2;
        private bool _hasMouse3;
        private int _currentSelectedUserProfileIndex;


        public ObservableCollection<string> UserProfileNameList
        {
            get { return _userProfileNameList; }
            set
            {
                if (_userProfileNameList != value)
                {
                    _userProfileNameList = value;
                    OnPropertyChanged(nameof(UserProfileNameList));
                }
            }
        }
        public List<IMouse> ConnectedMouseList
        {
            get { return _connectedMouseList; }
            set
            {
                if (_connectedMouseList != value)
                {
                    _connectedMouseList = value;
                    OnPropertyChanged(nameof(ConnectedMouseList));
                }
            }
        }
        public string MouseContainerButtonName1
        {
            get { return _mouseContainerButtonName1; }
            set
            {
                if (_mouseContainerButtonName1 != value)
                {
                    _mouseContainerButtonName1 = value;
                    OnPropertyChanged(nameof(MouseContainerButtonName1));
                }
            }
        }
        public string MouseContainerButtonName2
        {
            get { return _mouseContainerButtonName2; }
            set
            {
                if (_mouseContainerButtonName2 != value)
                {
                    _mouseContainerButtonName2 = value;
                    OnPropertyChanged(nameof(MouseContainerButtonName2));
                }
            }
        }
        public string MouseContainerButtonName3
        {
            get { return _mouseContainerButtonName3; }
            set
            {
                if (_mouseContainerButtonName3 != value)
                {
                    _mouseContainerButtonName3 = value;
                    OnPropertyChanged(nameof(MouseContainerButtonName3));
                }
            }
        }
        public int CurrentSelectedUserProfileIndex
        {
            get { return _currentSelectedUserProfileIndex; }
            set
            {
                if (_currentSelectedUserProfileIndex != value)
                {
                    _currentSelectedUserProfileIndex = value;
                    OnPropertyChanged(nameof(CurrentSelectedUserProfileIndex));
                    
                }
            }
        }
        public IUserProfile CurrentSelectedUserProfile
        {
            get { return _currentSelectedUserProfile; }
            set
            {
                if (_currentSelectedUserProfile != value)
                {
                    _currentSelectedUserProfile = value;
                    OnPropertyChanged(nameof(CurrentSelectedUserProfileIndex));

                }
            }
        }
        public UserProfileViewModel(MainViewModel mainViewModel)
        {



            _mainViewModel = mainViewModel;
            _modelFacade = _mainViewModel._modelFacade;
            _userProfileList = _modelFacade.userProfileController.GetUserProfileList();
            _hasMouse1 = false;
            _hasMouse2 = false;
            _hasMouse3 = false;

            ButtonMouseContainerCommand = new RelayCommand(ButtonMouseContainerHandler);
            AddNewUserProfileCommand = new RelayCommand(o => AddNewUserProfile());
            DeleteCurrentProfileCommand = new RelayCommand(o => DeleteSelectedUserProfile());
            UpdateCommand = new RelayCommand(o => UpdateProfileButtonLink());

            CurrentSelectedUserProfileIndex = 0;
            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(_userProfileList[CurrentSelectedUserProfileIndex]);
            ConnectedMouseList = _modelFacade.userProfileController.GetListOfConnectedMice(_userProfileList[CurrentSelectedUserProfileIndex]);

            UserProfileNameList = new ObservableCollection<string>();
            SetUserProfileNameList();

            MouseContainerButtonName1 = "Add Mouse";
            MouseContainerButtonName2 = "Add Mouse";
            MouseContainerButtonName3 = "Add Mouse";


    }

        public void AddNewUserProfile()
        {
            try
            {
                _mainViewModel.ShowAddProfilePopup();
                _modelFacade.userProfileController.CreateUserProfile(_mainViewModel.NewProfileName);
                SetUserProfileNameList();
                _mainViewModel.NewProfileName = "";
                CurrentSelectedUserProfileIndex = _userProfileList.Count - 1;
               
                UpdateProfileButtonLink();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error: Profile with that name already exists");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void DeleteSelectedUserProfile()
        {
            try
            {
                _modelFacade.userProfileController.RemoveUserProfile(_userProfileList[CurrentSelectedUserProfileIndex]);
                SetUserProfileNameList();


                CurrentSelectedUserProfileIndex = 0;
                UpdateProfileButtonLink();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
      

        public void ButtonMouseContainerHandler(object parameter)
        {
            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(GetCurrentlySelectedUserProfile());
            _mainViewModel.SetAvailableMouseNameList();
            UpdateProfileButtonLink();
            int numSwitch = int.Parse(parameter.ToString());
            int connectedCount = ConnectedMouseList.Count;

            switch(numSwitch)
            {
                case 1:

                    if (!_hasMouse1)
                    {
                        try
                        {
                            _mainViewModel.ShowAddMousePopup();
                            MouseContainerButtonName1 = _mainViewModel.CurrentSelectedAvailableMouseName;
                            _connectedMouse1 = GetCurrentSelectedAvailableMouse();
                            _modelFacade.userProfileRepo.AddMouseToProfile(GetCurrentlySelectedUserProfile(), _connectedMouse1);
                            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(GetCurrentlySelectedUserProfile());
                            _mainViewModel.SetAvailableMouseNameList();
                            _mainViewModel.CurrentSelectedAvailableMouseIndex = 0;
                            _hasMouse1 = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    } 
                    else
                    {
                        ChosenMouse = _connectedMouse1;
                        _mainViewModel.ShowMouseHubView();
                    }
                    break;

                case 2:

                    if (!_hasMouse2)
                    {
                        try
                        {
                            _mainViewModel.ShowAddMousePopup();
                            MouseContainerButtonName2 = _mainViewModel.CurrentSelectedAvailableMouseName;
                            _connectedMouse2 = GetCurrentSelectedAvailableMouse();
                            _modelFacade.userProfileRepo.AddMouseToProfile(GetCurrentlySelectedUserProfile(), _connectedMouse2);
                            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(GetCurrentlySelectedUserProfile());
                            _mainViewModel.SetAvailableMouseNameList();
                            _mainViewModel.CurrentSelectedAvailableMouseIndex = 0;
                            _hasMouse2 = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }

                    }
                    else
                    {
                        ChosenMouse = _connectedMouse2;
                        _mainViewModel.ShowMouseHubView();
                    }
                    break;

                case 3:

                    if (!_hasMouse3)
                    {
                        try
                        {
                            _mainViewModel.ShowAddMousePopup();
                            MouseContainerButtonName3 = _mainViewModel.CurrentSelectedAvailableMouseName;
                            _connectedMouse3 = GetCurrentSelectedAvailableMouse();
                            _modelFacade.userProfileRepo.AddMouseToProfile(GetCurrentlySelectedUserProfile(), _connectedMouse3);
                            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(GetCurrentlySelectedUserProfile());
                            _mainViewModel.SetAvailableMouseNameList();
                            _mainViewModel.CurrentSelectedAvailableMouseIndex = 0;
                            _hasMouse3 = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }

                    }
                    else
                    {
                        ChosenMouse = _connectedMouse3;
                        _mainViewModel.ShowMouseHubView();
                    }
                    break;
            }
            _mainViewModel.AvailableMouseList = _modelFacade.userProfileController.GetAvailableMiceToAddList(GetCurrentlySelectedUserProfile());
            _mainViewModel.SetAvailableMouseNameList();
            UpdateProfileButtonLink();
        }
        public void UpdateProfileButtonLink()
        {
            IUserProfile currentProfile = GetCurrentlySelectedUserProfile();
            List<IMouse> connectedMouseList = _modelFacade.userProfileController.GetListOfConnectedMice(currentProfile);

            _hasMouse1 = false;
            _hasMouse2 = false;
            _hasMouse3 = false;

            string buttonName1 = "";
            string buttonName2 = "";
            string buttonName3 = "";


            int switchNum = connectedMouseList.Count;
            switch(switchNum)
            {
                case 0:

                    buttonName1 = "Add Mouse";
                    MouseContainerButtonName1 = buttonName1;
                    buttonName2 = "Add Mouse";
                    MouseContainerButtonName2 = buttonName2;
                    buttonName3 = "Add Mouse";
                    MouseContainerButtonName3 = buttonName3;
                    break;
                case 1:
                    _hasMouse1 = true;
                    buttonName1 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[0]);
                    MouseContainerButtonName1 = buttonName1;
                    buttonName2 = "Add Mouse";
                    MouseContainerButtonName2 = buttonName2;
                    buttonName3 = "Add Mouse";
                    MouseContainerButtonName3 = buttonName3;

                    break;
                case 2:
                    _hasMouse1 = true;
                    _hasMouse2 = true;
                    buttonName1 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[0]);
                    MouseContainerButtonName1 = buttonName1;
                    buttonName2 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[1]);
                    MouseContainerButtonName2 = buttonName2;
                    buttonName3 = "Add Mouse";
                    MouseContainerButtonName3 = buttonName3;
                    break;
                case 3:
                    _hasMouse1 = true;
                    _hasMouse2 = true;
                    _hasMouse3 = true;
                    buttonName1 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[0]);
                    MouseContainerButtonName1 = buttonName1;
                    buttonName2 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[1]);
                    MouseContainerButtonName2 = buttonName2;
                    buttonName3 = _modelFacade.mouseController.GetMouseModelName(connectedMouseList[2]);
                    MouseContainerButtonName3 = buttonName3;
                    break;
            }
        }
        private void SetUserProfileNameList()
        {
            UserProfileNameList.Clear();
            foreach (IUserProfile userProfile in _userProfileList)
            {
                UserProfileNameList.Add(_modelFacade.userProfileController.GetUserProfileName(userProfile));
            }
        }
        private IUserProfile GetCurrentlySelectedUserProfile()
        {
            return _userProfileList[CurrentSelectedUserProfileIndex];
        }
        private IMouse GetCurrentSelectedAvailableMouse()
        {
            return _mainViewModel.AvailableMouseList[_mainViewModel.CurrentSelectedAvailableMouseIndex];
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}



