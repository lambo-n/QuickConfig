using System.Collections.Generic;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;

namespace WPFAppMouseSettingsHub.BusinessLogic.InterfacesBLL
{
    public interface IMouseController
    {
        string GetMouseModelName(IMouse mouse);
        string GetMouseColorHex( IMouse mouse);
        int GetMouseCurrentDPI(IMouse mouse);
        int GetMouseNumButtons( IMouse mouse);
        bool GetHasMouseAccelOn(IMouse mouse);
        bool GetMouseHasRGB(IMouse mouse);
        Dictionary<string, string> GetMouseRemapHashmap(IMouse mouse);
        IMouse CreateMouse(string modelName, int numButtons, bool hasRGB);
        void ChangeDPI(IMouse mouse, int newDPI);
        void ChangeSavedDPIOption(IMouse mouse, int dpiToChange, int newDPIOption);
        void ChangeColor( IMouse mouse, string newColorHex);
        void ChangeMouseAccel( IMouse mouse, bool mouseAccelOn);
        void RemapMouseButtons( IMouse mouse, string targetButton, string buttonRemap);
        void ResetMouseDPI(IMouse mouse);
        void ResetMouseColor( IMouse mouse);
        void ResetMouseRemapHash( IMouse mouse);
        bool CheckHasSavedDPIOption(IMouse mouse, int dpiToChange);
        void SortSavedDPIArray(IMouse mouse);
    }
}