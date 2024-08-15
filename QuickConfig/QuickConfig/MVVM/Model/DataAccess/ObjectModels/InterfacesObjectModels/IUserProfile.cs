using System.Collections.Generic;

namespace QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels
{
    public interface IUserProfile
    {
        List<IMouse> connectedMiceList { get; }
        List<string> savedColorHexList { get; }
        int numMice { get; set; }
        string profileName { get; set; }
    }
}
