using JWReport.Models;
using JWReport.Pages;
using JWReport.Services;
using JWReport.Services.Interface;
using JWReport.Services.Navigation;
using JWReport.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using Xamarin.Forms;

namespace JWReport.PageModels.Base
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
            _container = new TinyIoCContainer();
            _viewLookup = new Dictionary<Type, Type>();

            //Register pages and pageModels
            Register<WelcomePrivilegePageModel, WelcomePrivilegePage>();
            Register<WelcomeProfilePageModel, WelcomeProfilePage>();
            Register<WelcomeGroupOverseerPageModel, WelcomeGroupOverseerPage>();

            Register<BibleStudiesPageModel, BibleStudiesPage>();
            Register<FieldPageModel, FieldPage>();
            Register<FirstTimePageModel, FirstTimePage>();
            Register<HistoryPageModel, HistoryPage>();
            Register<ReportDayPageModel, ReportDayPage>();
            Register<ReportMonthPageModel, ReportMonthPage>();
            Register<ReturnVisitsPageModel, ReturnVisitsPage>();
            Register<ScheduleVisitPageModel, ScheduleVisitPage>();
            //Register<CustomAppShellModel, CustomAppShell>();
            //Register<FieldPageModel, CustomAppShell>();

            // Register services (Services are registered as singletons by default
            _container.Register<INavigationService, NavigationService>();
            _container.Register<IUserRepository, UserRepository>();
            _container.Register<IGroupOverseerRepository, GroupOverseerRepository>();
            //_container.Register<IAccountService>(DependencyService.Get<IAccountService>());
            //_container.Register(DependencyService.Get<IRepository<TestData>>());
        }

        /// <summary>
        /// Private utility method to Register page and page model for page retrieval by it's
        /// specified page model type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType = _viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            return page;
        }

        static void Register<TPageModel, TPage>() where TPageModel : PageModelBase where TPage : Page
        {
            _viewLookup.Add(typeof(TPageModel), typeof(TPage));
            _container.Register<TPageModel>();
        }
    }
}
