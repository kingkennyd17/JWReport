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
    public partial class ReturnVisitsPage : ContentPage
    {
        IReturnVisitRepository returnVisitRepository = new ReturnVisitRepository();

        public ReturnVisitsPage()
        {
            InitializeComponent();
            BindingContext = new ReturnVisitsPageModel(returnVisitRepository);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new ReturnVisitsPageModel(returnVisitRepository);
        }
    }
}