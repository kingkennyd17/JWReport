using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.Services.Navigation
{
    public class AppNavigationService
    {
        private static AppNavigationService _instance;
        public static AppNavigationService Instance => _instance ?? (_instance = new AppNavigationService());

        public FlyoutPage FlyoutPage { get; set; }

        private AppNavigationService()
        {
        }
    }
}
