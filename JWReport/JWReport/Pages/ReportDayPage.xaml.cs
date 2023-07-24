using JWReport.PageModels;
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
    public partial class ReportDayPage : ContentPage
    {
        public ReportDayPage()
        {
            InitializeComponent();
            BindingContext = new ReportDayPageModel();
        }
    }
}