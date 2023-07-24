using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JWReport.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DropdownEntryView : ContentView
	{
		public DropdownEntryView ()
		{
			InitializeComponent ();
		}

        private string selectedItem;
        public void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            selectedItem = picker.SelectedItem.ToString();
        }
    }
}