using JWReport.PageModels;
using JWReport.Services.Interface;
using JWReport.Services.Repository;
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
    public partial class FirstTimePage : ContentPage
    {
        IFirstTimeRepository firstTimeRepository = new FirstTimeRepository();
        IDailyReportRepository dailyReportRepository = new DailyReportRepository();
        public FirstTimePage()
        {
            InitializeComponent();
            BindingContext = new FirstTimePageModel(firstTimeRepository, dailyReportRepository);
        }
    }
}