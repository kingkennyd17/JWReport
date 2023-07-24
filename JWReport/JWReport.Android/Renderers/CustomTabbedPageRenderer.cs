using Android.Content;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Tabs;
using JWReport.Views.Layouts;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms;
using JWReport.Droid.Renderers;
//using Android.Support.Design.Widget;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace JWReport.Droid.Renderers
{
    internal class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void SetTabIcon(TabLayout.Tab tab, FileImageSource icon)
        {
            if (Element is CustomTabbedPage customTabbedPage && customTabbedPage.IsHidden)
            {
                tab.SetCustomView(new Android.Views.View(Context)); // Hide the tab by setting an empty view
                return;
            }

            base.SetTabIcon(tab, icon);
        }
    }
}