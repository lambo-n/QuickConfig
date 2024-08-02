using System.Collections.Generic;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;

namespace WPFAppMouseSettingsHub.DataAccess.InterfacesDAL
{
    public interface IMouseRepo
    {
        Dictionary<string, string> GetRemapHashmap(IMouse mouse);
        int[] GetSavedDPIArray(IMouse mouse);
        string GetMouseModelName(IMouse mouse);
        string GetMouseColorHex(IMouse mouse);
        bool GetHasMouseAccelOn(IMouse mouse);
        bool GetMouseHasRGB(IMouse mouse);
        int GetMouseNumButtons(IMouse mouse);
        int GetMouseDPI(IMouse mouse);
        void SetMouseModelName(IMouse mouse, string modelName);
        void SetMouseColorHex(IMouse mouse, string newColorHex);
        void SetMouseHasRGB(IMouse mouse, bool hasRGB);
        void SetMouseHasAccelOn(IMouse mouse, bool hasAccelOn);
        void SetNumMouseButtons(IMouse mouse, int newNumButtons);        
        void SetMouseDPI(IMouse mouse, int newDPI);
        void SetDefaultRemapHash(IMouse mouse);
        void ChangeSavedDPIOptions(IMouse mouse, int dpiToChange, int newDPIOption);
        void RemapMouseButtons(IMouse mouse, string targetButton, string newButtonRemap);
        IMouse CreateMouse(string modelName, int numButtons, bool hasRGB);

    }
}