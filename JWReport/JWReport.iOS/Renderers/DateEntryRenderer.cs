using Foundation;
using JWReport.iOS.Renderers;
using JWReport.Views.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(DateEntry), typeof(DateEntryRenderer))]
namespace JWReport.iOS.Renderers
{
    public class DateEntryRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement is DateEntry customDatePicker)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Text = customDatePicker.Placeholder;
                Control.TextColor = UIColor.Black; // Customize the placeholder color if desired
            }
        }
    }
}