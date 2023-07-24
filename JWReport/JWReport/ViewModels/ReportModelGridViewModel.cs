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

        private async void DecreaseAction()
        {
            BaseRepository<DailyReport> database = await DailyReportRepository.Instance;
            if (Text == "Placement")
            {
                await _dailyReportRepository.DecrementPlacement();
            }
            else if(Text == "Video")
            {
                await _dailyReportRepository.DecrementVideo();
            }
            else if (Text == "Hour")
            {
                await _dailyReportRepository.DecrementHour();
            }
            else if (Text == "Return Visit")
            {
                await _dailyReportRepository.DecrementReturnVisit();
            }
            else if (Text == "Bible Study")
            {
                await _dailyReportRepository.DecrementBibleStudy();
            }
        }

        private async void IncreaseAction()
        {
            BaseRepository<DailyReport> database = await DailyReportRepository.Instance;
            if (Text == "Placement")
            {
                await _dailyReportRepository.IncrementPlacement();
            }
            else if (Text == "Video")
            {
                await _dailyReportRepository.IncrementVideo();
            }
            else if (Text == "Hour")
            {
                await _dailyReportRepository.IncrementHour();
            }
            else if (Text == "Return Visit")
            {
                await _dailyReportRepository.IncrementReturnVisit();
            }
            else if (Text == "Bible Study")
            {
                await _dailyReportRepository.IncrementBibleStudy();
            }
        }
    }
}
