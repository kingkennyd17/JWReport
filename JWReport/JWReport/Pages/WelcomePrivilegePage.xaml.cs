using JWReport.PageModels;
using JWReport.Services.Navigation;
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
    public partial class WelcomePrivilegePage : ContentPage
    {
        public WelcomePrivilegePage()
        {
            InitializeComponent();
            BindingContext = new WelcomePrivilegePageModel();
        }
    }
}