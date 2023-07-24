using Android.Content;
using JWReport.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using JWReport.Views.Entries;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace JWReport.Droid.Renderers
{
    public class PlainEntryRenderer : EntryRenderer
    {
        public PlainEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
            }

        }
    }
}