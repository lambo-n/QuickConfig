using System.Collections.Generic;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;

namespace QuickConfig.DataAccess.ObjectModels
{
    public class Mouse : IMouse
    {
        private Dictionary<string, string> remapHashmap;
        public int[] savedDPIArray { get; }
        public int numButtons { get; set; }
        public int mouseDPI {  get; set; }
        public string modelName { get; set; }
        public string currentColorHex { get; set; }
        public bool hasMouseAccelOn { get; set; }
        public bool hasRGB {  get; set; }


        public Mouse(string modelName, int numMouseButtons, bool hasRGB)
        {
            remapHashmap = new Dictionary<string, string>();
            savedDPIArray = new int[4];
            this.numButtons = numMouseButtons;
            this.modelName = modelName;
            this.hasRGB = hasRGB;
            mouseDPI = 400;
            if(hasRGB)
            {
                currentColorHex = "000000";
            }
            SetDefaultRemapHash();
            SetDefaultSavedDPI();
        }
        public Dictionary<string, string> GetRemapHashmap()
        {
            return remapHashmap;
        }
        // all mouse buttons unbound by default
        public void SetDefaultRemapHash()
        {
            for (int i = 0; i < numButtons; i++)
            {
                string mouseButtonName = "mousebutton" + i;
                remapHashmap[mouseButtonName] = "-No remap-";
            }
        }
        // default dpi quick-chagne list
        public void SetDefaultSavedDPI()
        {
            savedDPIArray[0] = 400;
            savedDPIArray[1] = 800;
            savedDPIArray[2] = 1600;
            savedDPIArray[3] = 3200;
        }
    }
}
