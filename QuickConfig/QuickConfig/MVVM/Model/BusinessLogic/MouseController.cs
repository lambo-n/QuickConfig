using System;
using System.Collections.Generic;
using System.Linq;
using QuickConfig.BusinessLogic.InterfacesBLL;
using QuickConfig.DataAccess.InterfacesDAL;
using QuickConfig.DataAccess.ObjectModel.InterfacesObjectModels;

namespace QuickConfig.BusinessLogic
{
    public class MouseController : IMouseController
    {
        private readonly IMouseRepo mouseRepo;

        public MouseController(IMouseRepo mouseRepo) 
        { 
            this.mouseRepo = mouseRepo;
        }

        public int[] GetSavedDPIArray(IMouse mouse)
        {
            return mouseRepo.GetSavedDPIArray(mouse);
        }
        public string GetMouseModelName(IMouse mouse)
        {
            return mouseRepo.GetMouseModelName(mouse);
        }
        public string GetMouseColorHex(IMouse mouse)
        {
            return mouseRepo.GetMouseColorHex(mouse);
        }
        public int GetMouseCurrentDPI(IMouse mouse)
        {
            return mouseRepo.GetMouseDPI(mouse);
        }
        public int GetMouseNumButtons(IMouse mouse)
        {
            return mouseRepo.GetMouseNumButtons(mouse);
        }
        public bool GetHasMouseAccelOn(IMouse mouse)
        {
            return mouseRepo.GetHasMouseAccelOn(mouse);
        }
        public bool GetMouseHasRGB(IMouse mouse)
        {
            return mouseRepo.GetMouseHasRGB(mouse);
        }
        public Dictionary<string, string> GetMouseRemapHashmap(IMouse mouse)
        {
            return mouseRepo.GetRemapHashmap(mouse);
        }
        public IMouse CreateMouse(string modelName, int numButtons, bool hasRGB)
        {
            return mouseRepo.CreateMouse(modelName, numButtons, hasRGB);
        }
        public void ChangeDPI(IMouse mouse, int newDPI)
        {
            mouseRepo.SetMouseDPI(mouse, newDPI);
        }
        // changes list of saved DPI options unique to each mouse
        public void ChangeSavedDPIOption(IMouse mouse, int dpiToChange, int newDPIOption)
        {
            if (CheckHasSavedDPIOption(mouse, dpiToChange))
            {
                throw new NullReferenceException("requested DPI not in saved list");
            }
            else
            {
                mouseRepo.ChangeSavedDPIOptions(mouse, dpiToChange, newDPIOption);
            }
        }
        public void ChangeColor(IMouse mouse, string newColorHex)
        {
            bool hasRGB = mouseRepo.GetMouseHasRGB(mouse);

            if(!hasRGB)
            {
                throw new NullReferenceException("Mouse does not have RGB functionality");
            }
            else
            {
                mouseRepo.SetMouseColorHex(mouse, newColorHex);
            }
        }
        public void ChangeMouseAccel(IMouse mouse, bool newHasAccelOn)
        {
            bool currentMouseAccelOn = mouseRepo.GetHasMouseAccelOn(mouse);

            if(currentMouseAccelOn == newHasAccelOn)
            {
                throw new InvalidOperationException("Mouse accel bool not changed");
            }
            else
            {
                mouseRepo.SetMouseHasAccelOn(mouse, newHasAccelOn);
            }
        }
        // changes remapped keybinds unique to each mouse
        public void RemapMouseButtons(IMouse mouse, string targetMouseButton, string keyToRemap)
        {
            Dictionary<string, string> remapHashmap = mouseRepo.GetRemapHashmap(mouse);

            if (remapHashmap[targetMouseButton] == keyToRemap)
            {
                throw new InvalidOperationException("Duplicate remap");
            }
            else
            {
                mouseRepo.RemapMouseButtons(mouse, targetMouseButton, keyToRemap);
            }
        }
        // reset to default methods
        public void ResetMouseDPI(IMouse mouse)
        {
            mouseRepo.SetMouseDPI(mouse, 400);
        }
        public void ResetMouseColor(IMouse mouse)
        {
            bool hasRGB = mouseRepo.GetMouseHasRGB(mouse);

            if (!hasRGB)
            {
                throw new NullReferenceException("Mouse does not have RGB functionality");
            }
            else
            {
                mouseRepo.SetMouseColorHex(mouse, "000000");
            }
        }
        public void ResetMouseRemapHash(IMouse mouse)
        {
            mouseRepo.SetDefaultRemapHash(mouse);
        }
        // helper methods
        public bool CheckHasSavedDPIOption(IMouse mouse, int dpiToChange)
        {
            int[] savedDPIArray = mouseRepo.GetSavedDPIArray(mouse);

            if (savedDPIArray.Contains(dpiToChange))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SortSavedDPIArray(IMouse mouse)
        {
            Array.Sort(mouseRepo.GetSavedDPIArray(mouse));
        }
    }
}
