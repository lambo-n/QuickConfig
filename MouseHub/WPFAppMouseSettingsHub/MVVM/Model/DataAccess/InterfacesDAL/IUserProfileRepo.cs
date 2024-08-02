using System.Collections.Generic;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;

namespace WPFAppMouseSettingsHub.DataAccess.InterfacesDAL
{
    public interface IUserProfileRepo
    {
        IUserProfile GetDefaultUserProfile();
        List<IUserProfile> GetUserProfileList();
        List<IMouse> GetConnectedMiceList(IUserProfile userProfile);
        List<IMouse> GetCompatibleMiceList();
        List<string> GetSavedColorHexList(IUserProfile userProfile);
        int GetNumMiceInProfile(IUserProfile userProfile);
        string GetUserProfileName(IUserProfile userProfile);
        void SetCompatibleMiceList(List<IMouse> compatibleMiceList);
        void SetDefaultUserProfile(IUserProfile userProfile);
        void SetUserProfileName(IUserProfile userProfile, string newProfileName);
        void SetNumMiceInProfile(IUserProfile userProfile, int newNumMice);
        IUserProfile CreateUserProfile(string profileName);
        void RemoveUserProfile(IUserProfile userProfile);
        void AddMouseToProfile(IUserProfile userProfile, IMouse mouse);
        void RemoveMouseFromProfile(IUserProfile userProfile, IMouse mouse);
        void AddColorHexToSaved(IUserProfile userProfile, string newColorHex);
        void RemoveColorHexFromSaved(IUserProfile userProfile, string removedColorHex);
        void ClearSavedColorList(IUserProfile userProfile);

    }
}
