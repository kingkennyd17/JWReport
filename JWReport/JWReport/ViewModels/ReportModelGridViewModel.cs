using JWReport.Database;
using JWReport.Models;
using JWReport.PageModels.Base;
using JWReport.Services.Interface;
using JWReport.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.ViewModels
{
    public class ReportModelGridViewModel : ExtendedBindableObject
    {
        private IDailyReportRepository _dailyReportRepository;

        public NumberEntryViewModel NumberEntry { get; set; }
        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public ReportModelGridViewModel(IDailyReportRepository dailyReportRepository,string text, int initValue, bool hide) 
        {
            _dailyReportRepository = dailyReportRepository;

            Text = text;
            NumberEntry = new NumberEntryViewModel(initValue, hide, IncreaseAction, DecreaseAction);
        }
        public ReportModelGridViewModel(IDailyReportRepository dailyReportRepository, string text, TimeSpan hours)
        {
            _dailyReportRepository = dailyReportRepository;

            Text = text;
            NumberEntry = new NumberEntryViewModel(hours);
        }

        private async void DecreaseAction()
        {
            BaseRepository<DailyReport> database = await DailyReportRepository.Instance;
            if (Text == "Placement")
            {
                await _dailyReportRepository.DecrementPlacement();
                if(NumberEntry.Number > 0)
                    NumberEntry.Number--;
            }
            else if(Text == "Video")
            {
                await _dailyReportRepository.DecrementVideo();
                NumberEntry.Number--;
            }
            else if (Text == "Return Visit")
            {
                await _dailyReportRepository.DecrementReturnVisit();
                NumberEntry.Number--;
            }
        }

        private async void IncreaseAction()
        {
            BaseRepository<DailyReport> database = await DailyReportRepository.Instance;
            if (Text == "Placement")
            {
                await _dailyReportRepository.IncrementPlacement();
                NumberEntry.Number++;
            }
            else if (Text == "Video")
            {
                await _dailyReportRepository.IncrementVideo();
                NumberEntry.Number++;
            }
            else if (Text == "Return Visit")
            {
                await _dailyReportRepository.IncrementReturnVisit();
                NumberEntry.Number++;
            }
        }
    }
}
