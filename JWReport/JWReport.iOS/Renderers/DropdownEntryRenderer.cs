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

[assembly: ExportRenderer(typeof(DropdownEntry), typeof(DropdownEntryRenderer))]
namespace JWReport.iOS.Renderers
{
    public class DropdownEntryRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null && e.NewElement is DropdownEntry customPicker)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 0;
                Control.Layer.BorderWidth = 0;
                Control.TextAlignment = UITextAlignment.Left;
                Control.TextColor = customPicker.TextColor.ToUIColor();
                Control.Font = UIFont.SystemFontOfSize((float)customPicker.FontSize);
                Control.TintColor = UIColor.Clear;
                Control.InputView = new UIView();
                Control.InputAccessoryView = new UIView();

            }
        }
    }
}