using System.Collections.Generic;

namespace QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels
{
    public interface IMouse
    {
        int[] savedDPIArray {  get; }
        int numButtons { get; set; }
        int mouseDPI { get; set; }
        string modelName { get; set; }
        string currentColorHex { get; set; }
        bool hasRGB { get; set; }
        bool hasMouseAccelOn { get; set; }
        Dictionary<string, string> GetRemapHashmap();
        void SetDefaultRemapHash();
        void SetDefaultSavedDPI();
    }
}
