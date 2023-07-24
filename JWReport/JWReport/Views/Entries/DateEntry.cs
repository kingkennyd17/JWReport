using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.Views.Entries
{
    public class DateEntry : DatePicker
    {
        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(DateEntry), string.Empty);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
    }
}
