using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAppMouseSettingsHub.BusinessLogic.InterfacesBLL;
using WPFAppMouseSettingsHub.BusinessLogic;
using WPFAppMouseSettingsHub.DataAccess.InterfacesDAL;
using WPFAppMouseSettingsHub.DataAccess.ObjectModel.InterfacesObjectModels;
using WPFAppMouseSettingsHub.DataAccess;
using WPFAppMouseSettingsHub.DataAcess;
using WPFAppMouseSettingsHub.DataAccess.ObjectModels;

namespace WPFAppMouseSettingsHub.MVVM.Model
{
    public class ModelFacade
    {
        public IMouseRepo mouseRepo;
        public IUserProfileRepo userProfileRepo;

        public IUserProfileController userProfileController;
        public IMouseController mouseController;

        // test default/compatible mice
        public IMouse compatible0;
        public IMouse compatible1;
        public IMouse compatible2;
        public IMouse compatible3;
        public IMouse compatible4;

        public List<IMouse> availableMiceList;
        public List<IMouse> compatibleMiceList;

        public IUserProfile newUserProfile0;
        public IUserProfile newUserProfile1;
        public ModelFacade()
        {
            // instantiate layers
            mouseRepo = new MouseRepo();
            userProfileRepo = new UserProfileRepo();

            userProfileController = new UserProfileController(userProfileRepo);
            mouseController = new MouseController(mouseRepo);

            compatible0 = mouseController.CreateMouse("Logitech Pro X Superlight", 2, false);
            compatible1 = mouseController.CreateMouse("Logitech G502 Hero", 3, true);
            compatible2 = mouseController.CreateMouse("Razer Viper V3 Pro", 2, false);
            compatible3 = mouseController.CreateMouse("Razer Viper Mini Signature Edition", 2, true);
            compatible4 = mouseController.CreateMouse("Corsaire M65", 4, true);

            availableMiceList = new List<IMouse>();
            compatibleMiceList = new List<IMouse>()
            {
                compatible0,
                compatible1,
                compatible2,
                compatible3,
                compatible4,
            };
            // adds mice to compatible list
            userProfileController.CreateCompatibleMiceList(compatibleMiceList);
        }
        
    }
}
