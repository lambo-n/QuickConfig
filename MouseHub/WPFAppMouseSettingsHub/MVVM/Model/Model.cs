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

namespace WPFAppMouseSettingsHub.MVVM.Model
{
    public class Model
    {
        IMouseRepo mouseRepo;
        IUserProfileRepo userProfileRepo;

        IUserProfileController userProfileController;
        IMouseController mouseController;

        // test default/compatible mice
        IMouse compatible0;
        IMouse compatible1;
        IMouse compatible2;
        IMouse compatible3;
        IMouse compatible4;

        List<IMouse> availableMiceList;
        List<IMouse> compatibleMiceList;

        IUserProfile newUserProfile0;
        IUserProfile newUserProfile1;
        public Model()
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

            //get default profile, create 2nd profile
            newUserProfile0 = userProfileController.GetDefaultUserProfile();
            newUserProfile1 = userProfileController.CreateUserProfile("added profile");


        }
        
    }
}
