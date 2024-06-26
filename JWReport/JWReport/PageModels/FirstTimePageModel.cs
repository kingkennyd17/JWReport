﻿using JWReport.Database;
using JWReport.Models;
using JWReport.PageModels.Base;
using JWReport.Services.Helpers;
using JWReport.Services.Interface;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using JWReport.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.PageModels
{
    public class FirstTimePageModel : PageModelBase
    {
        IFirstTimeRepository _firstTimeRepository;
        IDailyReportRepository _dailyReportRepository;
        public FirstTimePageModel(IFirstTimeRepository firstTimeRepository, IDailyReportRepository dailyReportRepository)
        {
            _firstTimeRepository = firstTimeRepository;
            _dailyReportRepository = dailyReportRepository;
            string[] placementOption = new[] { "Placement", "Video", "Both" };

            NameEntryViewModel = new LoginEntryViewModel("name", false);
            AddressEntryViewModel = new LoginEntryViewModel("address", false);
            PhoneEntryViewModel = new LoginEntryViewModel("phone", false);
            NextQuestionEntryViewModel = new LoginEntryViewModel("next time question", false);
            NextMeetingEntryViewModel = new DateEntryViewModel(dateFormat, dateFormat + "(next meeting)");
            AddButton = new ButtonModel("+ Add", OnAddButton, true);
            PlacementnEntryViewModel = new DropdownEntryViewModel("Placement", placementOption);
        }

        private async void OnAddButton()
        {
            BaseRepository<ReturnVisit> database = await FirstTimeRepository.Instance;
            BaseRepository<DailyReport> dailyreportRepository = await DailyReportRepository.Instance;
            if (String.IsNullOrEmpty(NameEntryViewModel.Text)) 
            {
                DependencyService.Get<IMessage>().ShortAlert("Name Cannot be Empty!");
                return;
            }
            ReturnVisit firstTime = new ReturnVisit();
            firstTime.Name = NameEntryViewModel.Text;
            firstTime.Address = AddressEntryViewModel.Text;
            firstTime.Phone = PhoneEntryViewModel.Text;
            firstTime.NextQuestion = NextQuestionEntryViewModel.Text;
            firstTime.Upgraded = false;
            firstTime.ReturnType = "First Time";
            if (NextMeetingEntryViewModel.SelectedDate != null) firstTime.NextMeeting = DateTime.ParseExact(NextMeetingEntryViewModel.SelectedDate, dateFormatConvert, null);
            else firstTime.NextMeeting = null;
            //firstTime.NextMeeting = DateTime.ParseExact(NextMeetingEntryViewModel.SelectedDate, dateFormatConvert, null);
            //firstTime.Placement = PlacementnEntryViewModel.SelectedItem;

            await _firstTimeRepository.SaveAsync(firstTime);
            DependencyService.Get<IMessage>().ShortAlert("Saved!");


            if (PlacementnEntryViewModel.SelectedItem == "Video")
            {
                await _dailyReportRepository.IncrementVideo();
            }
            else if (PlacementnEntryViewModel.SelectedItem == "Placement")
            {
                await _dailyReportRepository.IncrementPlacement();
            }
            else if(PlacementnEntryViewModel.SelectedItem == "Both")
            {
                await _dailyReportRepository.IncrementVideo();
                await _dailyReportRepository.IncrementPlacement();
            }

            NameEntryViewModel.Text = "";
            AddressEntryViewModel.Text = "";
            PhoneEntryViewModel.Text = "";
            NextQuestionEntryViewModel.Text = "";
            NextMeetingEntryViewModel.SelectedDate = null;
            NextMeetingEntryViewModel.Placeholder = dateFormat + "(next meeting)";
            PlacementnEntryViewModel.SelectedItem = "";
        }

        public string dateFormat = "MM/dd/yyyy";
        public string dateFormatConvert = "MM/dd/yyyy HH:mm:ss";
        public LoginEntryViewModel NameEntryViewModel { get; set; }
        public LoginEntryViewModel AddressEntryViewModel { get; set; }
        public LoginEntryViewModel PhoneEntryViewModel { get; set; }
        public LoginEntryViewModel NextQuestionEntryViewModel { get; set; }
        public DropdownEntryViewModel PlacementnEntryViewModel { get; set; }

        private DateEntryViewModel _nextMeetingEntryViewModel;
        public DateEntryViewModel NextMeetingEntryViewModel 
        { 
            get => _nextMeetingEntryViewModel; 
            set => SetProperty(ref _nextMeetingEntryViewModel, value); 
        }
        public ButtonModel AddButton { get; set; }
    }
}
