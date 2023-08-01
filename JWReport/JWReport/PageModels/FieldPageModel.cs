using JWReport.Database;
using JWReport.Models;
using JWReport.PageModels.Base;
using JWReport.Pages;
using JWReport.Services.Interface;
using JWReport.Services.Navigation;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using JWReport.ViewModels.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JWReport.PageModels
{
    public class FieldPageModel : PageModelBase
    {
        IDailyReportRepository _dailyReportRepository;
        private Timer _timer;
        public FieldPageModel(IDailyReportRepository dailyReportRepository)
        {
            InstanciateTables();
            _dailyReportRepository = dailyReportRepository;
            ClockInOutButtonModel = new ButtonModel("START", new Command(OnClockInOutAction));
            TodayFieldStatus = new FieldStatusReportViewModel(_dailyReportRepository, "Month");
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Enabled = false;
            _timer.Elapsed += _timer_Elapsed;
            OnInit();
        }

        private async void InstanciateTables()
        {
            BaseRepository<DailyReport> dailyReport = await DailyReportRepository.Instance;
            BaseRepository<ReturnVisit> returnVisit = await ReturnVisitRepository.Instance;
        }

        private void OnInit()
        {
            var todayReport = _dailyReportRepository.GetReportbyDateAsync(DateTime.Today).Result;
            if (todayReport != null)
            {
                if (todayReport.OnField)
                {
                    IsClockedIn = true;
                    ClockInOutButtonModel.Text = "STOP";
                    TodayFieldStatus = new FieldStatusReportViewModel(_dailyReportRepository, "Day");
                    RunningTotal = DateTime.Now - todayReport.StartTime;
                    TodayFieldStatus.HourModelGrid.NumberEntry.Hours += (DateTime.Now - todayReport.StartTime);
                    _timer.Enabled = true;
                }
            }
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunningTotal += TimeSpan.FromSeconds(1);
            TodayFieldStatus.HourModelGrid.NumberEntry.Hours += TimeSpan.FromSeconds(1);
        }

        bool _isClockedIn;
        public bool IsClockedIn
        {
            get => _isClockedIn;
            set => SetProperty(ref _isClockedIn, value);
        }

        TimeSpan _runningTotal;
        public TimeSpan RunningTotal
        {
            get => _runningTotal;
            set => SetProperty(ref _runningTotal, value);
        }

        DateTime _currentStartTime;
        public DateTime CurrentStartTime
        {
            get => _currentStartTime;
            set => SetProperty(ref _currentStartTime, value);
        }

        double _todayEarnings;
        public double TodayEarnings
        {
            get => _todayEarnings;
            set => SetProperty(ref _todayEarnings, value);
        }

        ButtonModel _clockInOutButtonModel;
        public ButtonModel ClockInOutButtonModel
        {
            get => _clockInOutButtonModel;
            set => SetProperty(ref _clockInOutButtonModel, value);
        }

        private void OnClockInOutAction()
        {
            if (IsClockedIn)
            {
                var result = _dailyReportRepository.SaveEndAsync().Result;
                _timer.Enabled = false;
                RunningTotal = TimeSpan.Zero;
                ClockInOutButtonModel.Text = "START";

                TodayFieldStatus = new FieldStatusReportViewModel(_dailyReportRepository, "Month");
            }
            else
            {
                var result = _dailyReportRepository.SaveStartAsync().Result;
                CurrentStartTime = DateTime.Now;
                _timer.Enabled = true;
                ClockInOutButtonModel.Text = "STOP";

                TodayFieldStatus = new FieldStatusReportViewModel(_dailyReportRepository, "Day");
            }
            IsClockedIn = !IsClockedIn;
        }

        private FieldStatusReportViewModel _todayFieldStatus;
        public FieldStatusReportViewModel TodayFieldStatus 
        { 
            get => _todayFieldStatus; 
            set => SetProperty(ref _todayFieldStatus, value); 
        }
    }
}
