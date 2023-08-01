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
    public class FieldStatusReportViewModel : ExtendedBindableObject
    {
        IDailyReportRepository _dailyReportRepository;
        public FieldStatusReportViewModel(IDailyReportRepository dailyReportRepository, string displaytype) 
        {
            _dailyReportRepository = dailyReportRepository;
            OnInit(displaytype);
        }

        private void OnInit(string displayType)
        {
            //BaseRepository<MonthlyReport> database = await MonthlyReportRepository.Instance;
            if (displayType == "Day")
            {
                var currentReport = _dailyReportRepository.GetReportbyDateAsync(DateTime.Today).Result;
                HeaderLeftText = "Today";
                HeaderRightText = "Return Visits";
                if (currentReport != null)
                {
                    PlacementModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Placement", currentReport.Placement, true);
                    VideoModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Video", currentReport.Video, true);
                    HourModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Hour", currentReport.Time + currentReport.TimeAuto);
                    ReturnVisitModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Return Visit", currentReport.ReturnVisit, true);
                    BibleStudyModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Bible Study", currentReport.BibleStudy, false);
                }
                else
                {
                    PlacementModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Placement", 0, true);
                    VideoModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Video", 0, true);
                    HourModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Hour", TimeSpan.Zero);
                    ReturnVisitModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Return Visit", 0, true);
                    BibleStudyModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Bible Study", 0, false);
                }
            }
            else if (displayType == "Month")
            {
                List<DailyReport> currentReport = _dailyReportRepository.GetAllDailyReportforMonthAsync(DateTime.Now.ToString("MMMM")).Result;
                MonthlyReport monthlyReport = SumDailyReportArray(currentReport);
                HeaderLeftText = DateTime.Now.ToString("MMMM");
                HeaderRightText = "Pending Visits";
                if (currentReport != null)
                {
                    PlacementModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Placement", monthlyReport.Placement, false);
                    VideoModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Video", monthlyReport.Video, false);
                    HourModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Hour", monthlyReport.Time);
                    ReturnVisitModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Return Visit", monthlyReport.ReturnVisit, false);
                    BibleStudyModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Bible Study", monthlyReport.BibleStudy, false);
                }
                else
                {
                    PlacementModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Placement", 0, true);
                    VideoModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Video", 0, true);
                    HourModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Hour", TimeSpan.Zero);
                    ReturnVisitModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Return Visit", 0, true);
                    BibleStudyModelGrid = new ReportModelGridViewModel(_dailyReportRepository, "Bible Study", 0, false);
                }
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

        public static MonthlyReport SumDailyReportArray(List<DailyReport> dailyArray)
        {
            if (dailyArray == null || dailyArray.Count == 0)
            {
                return new MonthlyReport();
            }

            int sumPlacement = 0;
            int sumVideo = 0;
            TimeSpan totalTime = TimeSpan.Zero;
            TimeSpan totalTimeAuto = TimeSpan.Zero;
            int sumReturnVisit = 0;
            // Initialize other sum variables for additional properties if needed...

            foreach (var report in dailyArray)
            {
                sumPlacement += report.Placement;
                sumVideo += report.Video;
                sumReturnVisit += report.ReturnVisit;
                totalTime += report.Time;
                totalTimeAuto += report.TimeAuto;

                // Add other properties to their corresponding sum variables...
            }
            int totalHours = (totalTime + totalTimeAuto).Hours;

            MonthlyReport nonthlyReport = new MonthlyReport
            {
                Placement = sumPlacement,
                Video = sumVideo,
                Hour = (totalTime + totalTimeAuto).Hours,
                ReturnVisit = sumReturnVisit,
                ExtraMinute = (totalTime + totalTimeAuto) - TimeSpan.FromHours(totalHours),
                Time = totalTime + totalTimeAuto,
                Month = DateTime.Now.ToString("MMMM"),
                Year = DateTime.Now.Year
            };

            return nonthlyReport;
        }
    }
}
