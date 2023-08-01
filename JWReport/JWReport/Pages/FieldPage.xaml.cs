using JWReport.PageModels;
using JWReport.Services.Interface;
using JWReport.Services.Navigation;
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
    public partial class FieldPage : ContentPage
    {
        IDailyReportRepository dailyReportRepository = new DailyReportRepository();
        public FieldPage()
        {
            InitializeComponent();
            BindingContext = new FieldPageModel(dailyReportRepository);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new FieldPageModel(dailyReportRepository);
        }
    }
}