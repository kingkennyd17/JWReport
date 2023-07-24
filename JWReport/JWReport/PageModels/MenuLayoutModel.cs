using JWReport.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JWReport.PageModels
{
    public class MenuLayoutModel : PageModelBase
    {
        private BibleStudiesPageModel _bibleStudyPM;
        public BibleStudiesPageModel BibleStudiesPageModel
        {
            get => _bibleStudyPM;
            set => SetProperty(ref _bibleStudyPM, value);
        }

        private FieldPageModel _fieldPM;
        public FieldPageModel FieldPageModel
        {
            get => _fieldPM;
            set => SetProperty(ref _fieldPM, value);
        }

        private FirstTimePageModel _firstTimePM;
        public FirstTimePageModel FirstTimePageModel
        {
            get => _firstTimePM;
            set => SetProperty(ref _firstTimePM, value);
        }

        private HistoryPageModel _historyPM;
        public HistoryPageModel HistoryPageModel
        {
            get => _historyPM;
            set => SetProperty(ref _historyPM, value);
        }

        private ReportDayPageModel _reportDayPM;
        public ReportDayPageModel ReportDayPageModel
        {
            get => _reportDayPM;
            set => SetProperty(ref _reportDayPM, value);
        }

        private ReportMonthPageModel _reportMonthPM;
        public ReportMonthPageModel ReportMonthPageModel
        {
            get => _reportMonthPM;
            set => SetProperty(ref _reportMonthPM, value);
        }

        private ReturnVisitsPageModel _returnVisitsPM;
        public ReturnVisitsPageModel ReturnVisitsPageModel
        {
            get => _returnVisitsPM;
            set => SetProperty(ref _returnVisitsPM, value);
        }

        private ScheduleVisitPageModel _scheduleVisitPM;
        public ScheduleVisitPageModel ScheduleVisitPageModel
        {
            get => _scheduleVisitPM;
            set => SetProperty(ref _scheduleVisitPM, value);
        }

        public MenuLayoutModel(BibleStudiesPageModel bibleStudyPM, FieldPageModel fieldPM, FirstTimePageModel firstTimePM,
            HistoryPageModel historyPM, ReportDayPageModel reportDayPM, ReportMonthPageModel reportMonthPM, ReturnVisitsPageModel returnVisitsPM,
            ScheduleVisitPageModel scheduleVisitPM)
        {
            BibleStudiesPageModel = bibleStudyPM;
            FieldPageModel = fieldPM;
            FirstTimePageModel = firstTimePM;
            HistoryPageModel = historyPM;
            ReportDayPageModel = reportDayPM;
            ReportMonthPageModel = reportMonthPM;
            ReturnVisitsPageModel = returnVisitsPM;
            ScheduleVisitPageModel = scheduleVisitPM;
        }

        public override Task InitializeAsync(object navigationData)
        {
            return Task.WhenAny(base.InitializeAsync(navigationData),
                BibleStudiesPageModel.InitializeAsync(null),
                FieldPageModel.InitializeAsync(null),
                FirstTimePageModel.InitializeAsync(null),
                HistoryPageModel.InitializeAsync(null),
                ReportDayPageModel.InitializeAsync(null),
                ReportMonthPageModel.InitializeAsync(null),
                ReturnVisitsPageModel.InitializeAsync(null),
                ScheduleVisitPageModel.InitializeAsync(null));
        }
    }
}
