using JWReport.PageModels;
using JWReport.PageModels.Base;
using JWReport.Pages;
using JWReport.Services.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Application = Xamarin.Forms.Application;

namespace JWReport
{
    public partial class App : Application
    {
        public App()
        {
            Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
            InitializeComponent();

            var navService = PageModelLocator.Resolve<INavigationService>();
            MainPage = new AppShell();
        }

        Task InitNavigation()
        {
            var navService = PageModelLocator.Resolve<INavigationService>();
            return navService.NavigateToAsync<WelcomePrivilegePageModel>();
        }

        protected async override void OnStart()
        {
            //await InitNavigation();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
