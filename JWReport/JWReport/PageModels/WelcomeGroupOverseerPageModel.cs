using JWReport.ViewModels.Buttons;
using JWReport.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using JWReport.Services.Navigation;
using JWReport.PageModels.Base;
using JWReport.Database;
using JWReport.Models;
using JWReport.Services.Repository;
using JWReport.Models.Enum;
using System.Threading.Tasks;
using Xamarin.Forms;
using JWReport.Pages;

namespace JWReport.PageModels
{
    public class WelcomeGroupOverseerPageModel : PageModelBase
    {
        public WelcomeGroupOverseerPageModel()
        {
            string[] genderOption = new[] { "Male", "Female" };

            NameEntryViewModel = new LoginEntryViewModel("name (last and first name)", false);
            EmailEntryViewModel = new LoginEntryViewModel("email", false);
            DialCodeEntryViewModel = new LoginEntryViewModel("+1 (Code)", false);
            PhoneEntryViewModel = new LoginEntryViewModel("Phone", false);
            SubmitButton = new ButtonModel("Submit", OnSubmittAction, true);
            BackButton = new ButtonModel("Back", OnBackAction, true);

            this.InitializeAsync(null);
        }
        public async override Task InitializeAsync(object navigationData)
        {
            BaseRepository<GroupOverseer> database = await GroupOverseerRepository.Instance;
            GroupOverseer groupOverseer = new GroupOverseer();
            groupOverseer = await database.GetAsync(1);
            if (groupOverseer != null)
            {
                string[] phoneparts = groupOverseer.Phone.Split('-');
                NameEntryViewModel.Text = groupOverseer.Name;
                EmailEntryViewModel.Text = groupOverseer.Email;
                DialCodeEntryViewModel.Text = phoneparts[0].Trim();
                PhoneEntryViewModel.Text = phoneparts[1].Trim();
            }


            await base.InitializeAsync(navigationData);
        }

        private async void OnSubmittAction()
        {
            GroupOverseer overseerinfo = new GroupOverseer();
            overseerinfo.Name = NameEntryViewModel.Text;
            overseerinfo.Email = EmailEntryViewModel.Text;
            overseerinfo.Phone = DialCodeEntryViewModel.Text + "-" + PhoneEntryViewModel.Text;

            BaseRepository<GroupOverseer> database = await GroupOverseerRepository.Instance;
            await database.SaveAsync(overseerinfo);


            await Shell.Current.GoToAsync($"//{nameof(FieldPage)}");
        }

        private async void OnBackAction()
        {
            await Shell.Current.GoToAsync($"{nameof(WelcomeProfilePage)}?{nameof(WelcomeProfilePageModel.ItemId)}={null}");
        }

        public ButtonModel SubmitButton { get; set; }
        public ButtonModel BackButton { get; set; }
        public LoginEntryViewModel NameEntryViewModel { get; set; }
        public LoginEntryViewModel EmailEntryViewModel { get; set; }
        public LoginEntryViewModel DialCodeEntryViewModel { get; set; }
        public LoginEntryViewModel PhoneEntryViewModel { get; set; }
    }
}
