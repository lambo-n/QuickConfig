using System;
using System.Collections.Generic;
using QuickConfig.DataAccess.InterfacesDAL;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;
using QuickConfig.DataAccess.ObjectModels;

namespace QuickConfig.DataAcess
{
    public class UserProfileRepo : IUserProfileRepo
    {
        private List<IUserProfile> userProfileList;
        private List<IMouse> compatibleMiceList;
        private IUserProfile defaultUserProfile;

        public UserProfileRepo()
        {
            userProfileList = new List<IUserProfile>();
            compatibleMiceList = new List<IMouse>();
            defaultUserProfile = CreateUserProfile("Default Profile");
        }

        public string GetUserProfileName(IUserProfile userProfile)
        {
            return userProfile.profileName;
        }
        public void SetUserProfileName(IUserProfile userProfile, string newProfileName)
        {
            userProfile.profileName = newProfileName;
        }
        public int GetNumMiceInProfile(IUserProfile userProfile)
        {
            return userProfile.numMice;
        }
        public void SetNumMiceInProfile(IUserProfile userProfile, int newNumMice)
        {
            userProfile.numMice = newNumMice;
        }
        public IUserProfile GetDefaultUserProfile()
        {
            return defaultUserProfile;
        }
        public void SetDefaultUserProfile(IUserProfile userProfile)
        {
            defaultUserProfile = userProfile;
        }
        public List<IUserProfile> GetUserProfileList()
        {
            return userProfileList;
        }
        public List<IMouse> GetConnectedMiceList(IUserProfile userProfile)
        {
            return userProfile.connectedMiceList;
        }
        public List<IMouse> GetCompatibleMiceList()
        {
            return compatibleMiceList;
        }
        public void SetCompatibleMiceList(List<IMouse> compatibleMiceList)
        {
            this.compatibleMiceList = compatibleMiceList;
        }
        public List<string> GetSavedColorHexList(IUserProfile userProfile)
        {
            return userProfile.savedColorHexList;
        }


        public IUserProfile CreateUserProfile(string profileName)
        {
            IUserProfile userProfile = new UserProfile(profileName);
            userProfileList.Add(userProfile);
            return userProfile;
        }

        public void RemoveUserProfile(IUserProfile userProfile)
        {
            userProfileList.Remove(userProfile);
        }
        public void AddColorHexToSaved(IUserProfile userProfile, string newColorHex)
        {
            userProfile.savedColorHexList.Add(newColorHex);
        }
        public void AddMouseToProfile(IUserProfile userProfile, IMouse mouse)
        {
            List<IMouse> connectedMiceList = userProfile.connectedMiceList;
            connectedMiceList.Add(mouse);
        }
        public void RemoveColorHexFromSaved(IUserProfile userProfile, string removedColorHex)
        {
            userProfile.savedColorHexList.Remove(removedColorHex);
        }

        public void ClearSavedColorList(IUserProfile userProfile)
        {
            userProfile.savedColorHexList.Clear();
        }
        public void RemoveMouseFromProfile(IUserProfile userProfile, IMouse mouse)
        {
            throw new NotImplementedException();
        }
    }
}
