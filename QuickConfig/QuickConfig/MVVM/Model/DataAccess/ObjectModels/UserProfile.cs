using System.Collections.Generic;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;

namespace QuickConfig.DataAccess.ObjectModels
{
    public class UserProfile : IUserProfile
    {
        public List<IMouse> connectedMiceList { get; }
        public List<string> savedColorHexList { get; }


        public int numMice {  get; set; }
        public string profileName { get; set; }


        public UserProfile(string profileName) 
        {
            connectedMiceList = new List<IMouse>();
            savedColorHexList = new List<string>();

            numMice = 0;
            this.profileName = profileName;

        }

    }
}
