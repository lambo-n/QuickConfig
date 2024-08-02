using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFAppMouseSettingsHub.Core;

namespace WPFAppMouseSettingsHub.MVVM.ViewModel
{
    public class SensitivityViewModel
    {
        public ICommand SensitivityViewCommand { get; }

        public SensitivityViewModel(MouseSettingsViewModel mouseSettingsViewModel)
        {
            SensitivityViewCommand = new RelayCommand(_ => mouseSettingsViewModel.ShowSensitivityView());
        }

    }
}
