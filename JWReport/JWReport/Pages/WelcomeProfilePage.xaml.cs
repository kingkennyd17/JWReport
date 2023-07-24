using JWReport.PageModels;
using JWReport.Services.Interface;
using JWReport.Services.Navigation;
using JWReport.Services.Repository;
using JWReport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JWReport.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeProfilePage : ContentPage
    {
        IUserRepository userRepository = new UserRepository();

        public WelcomeProfilePage ()
		{
			InitializeComponent ();
            BindingContext = new WelcomeProfilePageModel(userRepository);
        }
    }
}