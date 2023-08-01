using JWReport.Models;
using JWReport.Models.HelperModel;
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
        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string previous = (e.PreviousSelection.FirstOrDefault() as RVPhoneMessageModel)?.Name;
            int? Id = (e.CurrentSelection.FirstOrDefault() as RVPhoneMessageModel)?.Id;
        }
    }
}