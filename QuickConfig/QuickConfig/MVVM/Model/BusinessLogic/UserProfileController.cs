using System;
using System.Collections.Generic;
using System.Linq;
using QuickConfig.BusinessLogic.InterfacesBLL;
using QuickConfig.DataAccess.InterfacesDAL;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;

namespace QuickConfig.BusinessLogic
{
    public class UserProfileController : IUserProfileController
    {
        private readonly IUserProfileRepo userProfileRepo;
        public UserProfileController(IUserProfileRepo userProfileRepo)
        {
            this.userProfileRepo = userProfileRepo;
        }

        public IUserProfile GetDefaultUserProfile()
        {
            return userProfileRepo.GetDefaultUserProfile();
        }
        public List<IUserProfile> GetUserProfileList()
        {
            return userProfileRepo.GetUserProfileList();
        }
        public List<IMouse> GetCompatibleMiceList()
        {
            return userProfileRepo.GetCompatibleMiceList();
        }
        // list of mice tied to user profile
        public List<IMouse> GetListOfConnectedMice(IUserProfile userProfile)
        {
            return userProfileRepo.GetConnectedMiceList(userProfile);
        }
        // gets (compatible list) - (connected list)
        public List<IMouse> GetAvailableMiceToAddList(IUserProfile userProfile)
        {
            List<IMouse> compatibleMiceList = GetCompatibleMiceList();
            List<IMouse> connectedMiceLIst = userProfileRepo.GetConnectedMiceList(userProfile);

            IEnumerable<IMouse> availableList = compatibleMiceList.Except(connectedMiceLIst);

            return availableList.ToList();
        }
        // list of saved color hex tied to user profile
        public List<string> GetSavedColorHexList(IUserProfile userProfile)
        {
            return userProfileRepo.GetSavedColorHexList(userProfile);
        }
        public int GetNumMiceInProfile(IUserProfile userProfile)
        {
            return userProfileRepo.GetNumMiceInProfile(userProfile);
        }
        public string GetUserProfileName(IUserProfile userProfile)
        {
            return userProfileRepo.GetUserProfileName(userProfile);
        }
        public void CreateCompatibleMiceList(List<IMouse> miceList)
        {
            userProfileRepo.SetCompatibleMiceList(miceList);
        }
        // changes default to another created user profile
        public void ChangeDefaultUserProfile(IUserProfile userProfile)
        {
            string userProfileName = userProfileRepo.GetUserProfileName(userProfile);
            IUserProfile currentDefaultProfile = userProfileRepo.GetDefaultUserProfile();

            if (currentDefaultProfile == userProfile)
            {
                throw new InvalidOperationException("Given user profile is already the default profile");
            }
            else if(!CheckUserProfileExists(userProfileName))
            {
                throw new NullReferenceException("Given user profile does not exist in list");
            }
            else
            {
                userProfileRepo.SetDefaultUserProfile(userProfile);
            }
        }
        public IUserProfile CreateUserProfile(string profileName)
        {
            bool isDupe = CheckUserProfileExists(profileName);

            if (isDupe)
            {
                throw new InvalidOperationException("Profile already exists");
            }
            else
            {
                return userProfileRepo.CreateUserProfile(profileName);
            }
        }
        // removes profile from profile list, sets new default profile if existing default is removed
        public void RemoveUserProfile(IUserProfile userProfileToRemove)
        {
           
            bool profileExists = CheckUserProfileExists(GetUserProfileName(userProfileToRemove));
            List<IUserProfile> userProfileList = userProfileRepo.GetUserProfileList();
            IUserProfile removedUserProfile;

            if (!profileExists)
            {
                throw new NullReferenceException("Profile name could not be matched to any saved user profile");
            }
            else if(userProfileList.Count <= 1)
            {
                throw new InvalidOperationException("Cannot remove the only remaining user profile");
            }
            else
            {
                foreach (IUserProfile existingProfile in userProfileList)
                {

                    if (existingProfile == userProfileToRemove)
                    {
                        if (userProfileToRemove == userProfileRepo.GetDefaultUserProfile())
                        {
                            int indexOfProfile = userProfileList.IndexOf(userProfileToRemove);
                            if (indexOfProfile <= 0)
                            {
                                userProfileRepo.SetDefaultUserProfile(userProfileList[indexOfProfile + 1]);
                            }
                            else
                            {
                                userProfileRepo.SetDefaultUserProfile(userProfileList[indexOfProfile - 1]);
                            }
                        }
                        removedUserProfile = existingProfile;
                    }
                }
                userProfileRepo.RemoveUserProfile(userProfileToRemove);
            }
        }
        public void AddMouseToProfile(IUserProfile userProfile, IMouse mouse)
        {
            List<IMouse> connectedMiceList = userProfileRepo.GetConnectedMiceList(userProfile);

            if (CheckCompatibleListIsEmpty())
            {
                throw new NullReferenceException("Compatible mice list is empty");
            }
            else if (!CheckMouseIsCompatible(mouse))
            {
                throw new NullReferenceException("Mouse is not compatible with hub");
            }
            else if (CheckMouseIsConnected(userProfile, mouse))
            {
                throw new InvalidOperationException("Given mouse is already connected to this profile");
            }
            else if (connectedMiceList.Count >= 3)
            {
                throw new InvalidOperationException("Cannot connect more than 3 mice to 1 profile");
            }
            else
            {
                userProfileRepo.AddMouseToProfile(userProfile, mouse);
            }
        }
        public void RemoveMouseFromProfile(IUserProfile userProfile, IMouse mouse)
        {
            if (!CheckMouseIsConnected(userProfile, mouse))
            {
                throw new NullReferenceException("Given mouse is not connected to this profile");
            }
            else
            {
                userProfileRepo.RemoveMouseFromProfile(userProfile, mouse);
            }
        }
        public void AddColorHexToSaved(IUserProfile userProfile, string newColorHex)
        {
            List<string> savedColorHexList = userProfileRepo.GetSavedColorHexList(userProfile);

            if(savedColorHexList.Contains(newColorHex))
            {
                throw new InvalidOperationException("Given color hex is already saved.");
            }
            else
            {
                userProfileRepo.AddColorHexToSaved(userProfile, newColorHex);
            }
        }
        public void RemoveColorHexFromSaved(IUserProfile userProfile, string removedColorHex)
        {
            List<string> savedColorHexList = userProfileRepo.GetSavedColorHexList(userProfile);

            if (!savedColorHexList.Contains(removedColorHex))
            {
                throw new InvalidOperationException("Given color hex cannot be removed as it is not in the list.");
            }
            else
            {
                userProfileRepo.RemoveColorHexFromSaved(userProfile, removedColorHex);
            }
        }
        public void ClearSavedColorList(IUserProfile userProfile)
        {
            userProfileRepo.ClearSavedColorList(userProfile);
        }
        // helper methods
        public bool CheckMouseIsCompatible(IMouse mouse)
        {
            List<IMouse> compatibleMiceList = userProfileRepo.GetCompatibleMiceList();

            foreach (IMouse compatibleMouse in compatibleMiceList)
            {
                if (mouse == compatibleMouse)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckCompatibleListIsEmpty()
        {
            List<IMouse> compatibleMiceList = userProfileRepo.GetCompatibleMiceList();

            if (compatibleMiceList.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckMouseIsConnected(IUserProfile userProfile, IMouse mouse)
        {
            List<IMouse> connectedMiceList = userProfileRepo.GetConnectedMiceList(userProfile);

            if (connectedMiceList.Contains(mouse))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckUserProfileExists(string profileName)
        {
            List<IUserProfile> userProfileList = userProfileRepo.GetUserProfileList();

            foreach (IUserProfile userProfile in userProfileList)
            {
                string currentProfileName = userProfileRepo.GetUserProfileName(userProfile);
                if (currentProfileName == profileName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
