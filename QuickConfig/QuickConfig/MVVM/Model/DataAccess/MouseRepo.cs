using System;
using System.Collections.Generic;
using QuickConfig.DataAccess.InterfacesDAL;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;
using QuickConfig.DataAccess.ObjectModels;

namespace QuickConfig.DataAccess
{
    public class MouseRepo : IMouseRepo
    {
        public MouseRepo()
        {
        }
        public Dictionary<string, string> GetRemapHashmap(IMouse mouse)
        {
            return mouse.GetRemapHashmap();
        }
        public int[] GetSavedDPIArray(IMouse mouse)
        {
            return mouse.savedDPIArray;
        }
        public string GetMouseModelName(IMouse mouse)
        {
            return mouse.modelName;
        }
        public string GetMouseColorHex(IMouse mouse)
        {
            return mouse.currentColorHex;
        }
        public bool GetHasMouseAccelOn(IMouse mouse)
        {
            return mouse.hasMouseAccelOn;
        }
        public bool GetMouseHasRGB(IMouse mouse)
        {
            return mouse.hasRGB;
        }
        public int GetMouseDPI(IMouse mouse)
        {
            return mouse.mouseDPI;
        }
        public int GetMouseNumButtons(IMouse mouse)
        {
            return mouse.numButtons;
        }
        public void SetMouseModelName(IMouse mouse, string modelName)
        {
            mouse.modelName = modelName;
        }
        public void SetMouseColorHex(IMouse mouse, string newColorHex)
        {
            mouse.currentColorHex = newColorHex;
        }
        public void SetMouseHasAccelOn(IMouse mouse, bool hasAccelOn)
        {
            mouse.hasMouseAccelOn = hasAccelOn;
        }
        public void SetMouseHasRGB(IMouse mouse, bool hasRGB)
        {
            mouse.hasRGB = hasRGB;
        }
        public void SetMouseDPI(IMouse mouse, int newDPI)
        {
            mouse.mouseDPI = newDPI;
        }
        public void SetNumMouseButtons(IMouse mouse, int newNumButtons)
        {
            mouse.numButtons = newNumButtons;
        }
        public void SetDefaultRemapHash(IMouse mouse)
        {
            mouse.SetDefaultRemapHash();
        }
        // changes 1 of 4 quick-change saved dpi slots
        public void ChangeSavedDPIOptions(IMouse mouse, int dpiToChange, int newDPIOption)
        {
            int[] savedDPIArray = mouse.savedDPIArray;
            int targetIndex = Array.IndexOf(savedDPIArray, dpiToChange);

            savedDPIArray[targetIndex] = newDPIOption;
        }
        // remaps 1 mouse button keybind
        public void RemapMouseButtons(IMouse mouse, string targetButton, string newButtonRemap)
        {
            Dictionary<string, string> remapHashmap = mouse.GetRemapHashmap();
            remapHashmap[targetButton] = newButtonRemap;
        }
        public IMouse CreateMouse(string modelName, int numButtons, bool hasRGB)
        {
            IMouse newMouse = new Mouse(modelName, numButtons, hasRGB);
            return newMouse;
        }
    }
}