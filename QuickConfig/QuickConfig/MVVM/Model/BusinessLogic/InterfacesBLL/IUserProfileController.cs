using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;
using System.Collections.Generic;

namespace QuickConfig.BusinessLogic.InterfacesBLL
{
    public interface IUserProfileController
    {
        IUserProfile GetDefaultUserProfile();
        List<IUserProfile> GetUserProfileList();
        List<IMouse> GetCompatibleMiceList();
        List<IMouse> GetListOfConnectedMice(IUserProfile userProfile);
        List<IMouse> GetAvailableMiceToAddList(IUserProfile userProfile);
        List<string> GetSavedColorHexList(IUserProfile userProfile);
        int GetNumMiceInProfile(IUserProfile userProfile);
        string GetUserProfileName(IUserProfile userProfile);
        void CreateCompatibleMiceList(List<IMouse> miceList);
        void ChangeDefaultUserProfile(IUserProfile userProfile);
        IUserProfile CreateUserProfile(string profileName);
        void RemoveUserProfile(IUserProfile userProfile);
        void AddMouseToProfile(IUserProfile userProfile, IMouse mouse);
        void RemoveMouseFromProfile(IUserProfile userProfile, IMouse mouse);       
        void AddColorHexToSaved(IUserProfile userProfile, string newColorHex);
        void RemoveColorHexFromSaved(IUserProfile userProfile, string removedColorHex);
        void ClearSavedColorList(IUserProfile userProfile);
        bool CheckMouseIsCompatible(IMouse mouse);
        bool CheckCompatibleListIsEmpty();
        bool CheckMouseIsConnected(IUserProfile userProfile, IMouse mouse);
        bool CheckUserProfileExists(string profileName);
    }
}
