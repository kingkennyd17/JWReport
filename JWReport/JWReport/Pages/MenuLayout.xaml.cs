using JWReport.PageModels;
using JWReport.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JWReport.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuLayout : TabbedPage
    {
        BibleStudiesPageModel bibleStudyPM = new BibleStudiesPageModel();
        FieldPageModel fieldPM = new FieldPageModel();
        FirstTimePageModel firstTimePM = new FirstTimePageModel();
        HistoryPageModel historyPM = new HistoryPageModel();
        ReportDayPageModel reportDayPM = new ReportDayPageModel();
        ReportMonthPageModel reportMonthPM = new ReportMonthPageModel();
        ReturnVisitsPageModel returnVisitsPM = new ReturnVisitsPageModel();
        ScheduleVisitPageModel scheduleVisitPM = new ScheduleVisitPageModel();
        public MenuLayout()
        {
            InitializeComponent();
            BindingContext = new MenuLayoutModel(bibleStudyPM, fieldPM, firstTimePM, historyPM, reportDayPM, reportMonthPM, returnVisitsPM, scheduleVisitPM);
        }
    }
}