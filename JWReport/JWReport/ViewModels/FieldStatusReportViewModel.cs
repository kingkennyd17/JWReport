using JWReport.PageModels.Base;
using JWReport.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.ViewModels
{
    public class FieldStatusReportViewModel : ExtendedBindableObject
    {
        IDailyReportRepository _dailyReportRepository;
        public FieldStatusReportViewModel(IDailyReportRepository dailyReportRepository, string displaytype) 
        {
            _dailyReportRepository = dailyReportRepository;
            if (displaytype == "Day")
            {
                PlacementModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Placement", 0, false);
                VideoModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Video", 0, false);
                HourModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Hour", 0, false);
                ReturnVisitModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Return Visit", 0, false);
                BibleStudyModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Bible Study", 0, false);
            }
        }

        private string _headerLeftText;
        public string HeaderLeftText
        {
            get => _headerLeftText;
            set => SetProperty(ref _headerLeftText, value);
        }
        private string _headerRightText;
        public string HeaderRightText
        {
            get => _headerRightText;
            set => SetProperty(ref _headerRightText, value);
        }

        public ReportModelGridViewModel PlacementModelGrid { get; set; }
        public ReportModelGridViewModel VideoModelGrid { get; set; }
        public ReportModelGridViewModel HourModelGrid { get; set; }
        public ReportModelGridViewModel ReturnVisitModelGrid { get; set; }
        public ReportModelGridViewModel BibleStudyModelGrid { get; set; }
    }
}
