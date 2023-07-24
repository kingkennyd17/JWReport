using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JWReport.Droid.Renderers;
using JWReport.Views.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DateEntry), typeof(DateEntryRenderer))]
namespace JWReport.Droid.Renderers
{
    public class DateEntryRenderer : DatePickerRenderer
    {
        public DateEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement is DateEntry customDatePicker)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
                Control.Text = customDatePicker.Placeholder;
                Control.SetTextColor(ColorStateList.ValueOf(Android.Graphics.Color.Black)); // Customize the placeholder color if desired
            }
        }
    }
}