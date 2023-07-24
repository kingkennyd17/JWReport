using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.Views.Layouts
{
    public class CustomTabbedPage : TabbedPage
    {
        public static readonly BindableProperty IsHiddenProperty =
         BindableProperty.Create(nameof(IsHidden), typeof(bool), typeof(CustomTabbedPage), false);

        public bool IsHidden
        {
            get => (bool)GetValue(IsHiddenProperty);
            set => SetValue(IsHiddenProperty, value);
        }
    }
}
