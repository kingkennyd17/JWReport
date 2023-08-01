using JWReport.Database;
using JWReport.Models;
using JWReport.PageModels.Base;
using JWReport.Pages;
using JWReport.Services.Navigation;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using JWReport.ViewModels.Buttons;
using JWReport.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JWReport.PageModels
{
    public class WelcomePrivilegePageModel : PageModelBase
    {
        public PrivilegeSelectionViewModel UnbaptizedPublisher { get; set; }
        public PrivilegeSelectionViewModel BaptizedPublisher { get; set; }
        public PrivilegeSelectionViewModel RegularPioneer { get; set; }
        public PrivilegeSelectionViewModel SpecialPioneer { get; set; }


        public WelcomePrivilegePageModel() 
        {
            //_navigationService = navigationService;
            ButtonModel unbaptizedButton = new ButtonModel("I am an unbaptized publisher", OnSelectPrivilege, "1");
            ButtonModel baptizedButton = new ButtonModel("I am a baptized publisher", OnSelectPrivilege, "2");
            ButtonModel regularButton = new ButtonModel("I am a regular pioneer", OnSelectPrivilege, "3");
            ButtonModel specialButton = new ButtonModel("I am a special poineer", OnSelectPrivilege, "4");


            UnbaptizedPublisher = new PrivilegeSelectionViewModel(unbaptizedButton);
            BaptizedPublisher = new PrivilegeSelectionViewModel(baptizedButton);
            RegularPioneer = new PrivilegeSelectionViewModel(regularButton);
            SpecialPioneer = new PrivilegeSelectionViewModel(specialButton);
        }

        private async void OnSelectPrivilege(string parameter)
        {
            await Shell.Current.GoToAsync($"{nameof(WelcomeProfilePage)}?{nameof(WelcomeProfilePageModel.ItemId)}={parameter}");
        }
    }
}
