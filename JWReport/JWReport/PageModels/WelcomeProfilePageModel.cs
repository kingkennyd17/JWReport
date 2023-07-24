using JWReport.Database;
using JWReport.Models;
using JWReport.Models.Enum;
using JWReport.PageModels.Base;
using JWReport.Pages;
using JWReport.Services.Interface;
using JWReport.Services.Navigation;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using JWReport.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace JWReport.PageModels
{

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class WelcomeProfilePageModel : PageModelBase
    {
        private INavigationService _navigationService;
        private IUserRepository _userRepository;
        public string param;
        private string itemId;
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                OnInit(value);
            }
        }

        public async void OnInit(string itemId)
        {
            try
            {
                if (itemId != null)
                    Privelege = (PrivilegeOfService)int.Parse(itemId.ToString());
                BaseRepository<User> database = await UserRepository.Instance;
                User userinfo = new User();
                userinfo = await database.GetAsync(1);
                if (userinfo != null)
                {
                    NameEntryViewModel.Text = userinfo.Name;
                    BaptismDateEntryViewModel.SelectedDate = userinfo.BaptismDate?.ToString(dateFormatConvert);
                    CongregationEntryViewModel.Text = userinfo.Congregation;
                    DateOfBirthEntryViewModel.SelectedDate = userinfo.DateOfBirth?.ToString(dateFormatConvert);
                    GenderEntryViewModel.SelectedItem = userinfo.Gender;
                    if (Privelege == 0)
                        Privelege = userinfo.Privilege;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public WelcomeProfilePageModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            string[] genderOption = new[] { "Male", "Female" };

            NameEntryViewModel = new LoginEntryViewModel("name (last and first name)", false);
            BaptismDateEntryViewModel = new DateEntryViewModel(dateFormat, dateFormat + " (Baptism Date)");
            CongregationEntryViewModel = new LoginEntryViewModel("congregation", false);
            DateOfBirthEntryViewModel = new DateEntryViewModel(dateFormat, dateFormat + " (Date of Birth)");
            GenderEntryViewModel = new DropdownEntryViewModel("Gender", genderOption);
            NextButton = new ButtonModel("Next", OnNextAction, true);
            BackButton = new ButtonModel("Back", OnBackAction, true);
        }

        private async void OnBackAction()
        {
            await Shell.Current.GoToAsync($"{nameof(WelcomePrivilegePage)}");
        }

        private async void OnNextAction()
        {
            User userinfo = new User();
            userinfo.Name = NameEntryViewModel.Text;
            userinfo.BaptismDate = DateTime.ParseExact(BaptismDateEntryViewModel.SelectedDate, dateFormatConvert, null);
            userinfo.Congregation = CongregationEntryViewModel.Text;
            userinfo.DateOfBirth = DateTime.ParseExact(DateOfBirthEntryViewModel.SelectedDate, dateFormatConvert, null);
            userinfo.Gender = GenderEntryViewModel.SelectedItem;
            userinfo.Privilege = Privelege;

            BaseRepository<User> database = await UserRepository.Instance;
            await _userRepository.SaveUserInfoAsync(userinfo);
            await Shell.Current.GoToAsync($"{nameof(WelcomeGroupOverseerPage)}");

        }

        PrivilegeOfService Privelege;
        //public async override Task InitializeAsync(object navigationData)
        //{
        //    if (param != null)
        //    Privelege = (PrivilegeOfService)int.Parse(navigationData.ToString());
        //    BaseRepository<User> database = await UserRepository.Instance;
        //    User userinfo = new User();
        //    userinfo = await database.GetAsync(1);
        //    if(userinfo != null)
        //    {
        //        NameEntryViewModel.Text = userinfo.Name;
        //        BaptismDateEntryViewModel.SelectedDate = userinfo.BaptismDate?.ToString(dateFormatConvert);
        //        CongregationEntryViewModel.Text = userinfo.Congregation;
        //        DateOfBirthEntryViewModel.SelectedDate = userinfo.DateOfBirth?.ToString(dateFormatConvert);
        //        GenderEntryViewModel.SelectedItem = userinfo.Gender;
        //        if (Privelege == 0)
        //            Privelege = userinfo.Privilege;
        //    }


        //    await base.InitializeAsync(navigationData);
        //}

        public string dateFormat = "MM/dd/yyyy";
        public string dateFormatConvert = "MM/dd/yyyy HH:mm:ss";
        //public User userinfo = new User();
        public ButtonModel NextButton { get; set; }
        public ButtonModel BackButton { get; set; }
        public LoginEntryViewModel NameEntryViewModel { get; set; }
        public DateEntryViewModel BaptismDateEntryViewModel { get; set; }
        public LoginEntryViewModel CongregationEntryViewModel { get; set; }
        public DateEntryViewModel DateOfBirthEntryViewModel { get; set; }
        public DropdownEntryViewModel GenderEntryViewModel { get; set; }
    }
}
