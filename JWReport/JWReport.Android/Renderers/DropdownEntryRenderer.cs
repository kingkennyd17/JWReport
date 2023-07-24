using Android.App;
using Android.Content;
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

[assembly: ExportRenderer(typeof(DropdownEntry), typeof(DropdownEntryRenderer))]
namespace JWReport.Droid.Renderers
{
    internal class DropdownEntryRenderer : PickerRenderer
    {
        public DropdownEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement is DropdownEntry customPicker)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
                //Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                //Control.SetTextSize(Android.Util.ComplexUnitType.Sp, (float)customPicker.FontSize);
                //Control.SetTextColor(customPicker.TextColor.ToAndroid());
                //Control.Background = null;
                //Control.Focusable = false;
                //Control.FocusableInTouchMode = false;
            }

        }
    }
}