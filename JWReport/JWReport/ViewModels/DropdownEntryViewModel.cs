using JWReport.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.ViewModels
{
    public class DropdownEntryViewModel : ExtendedBindableObject
    {
        public DropdownEntryViewModel(string title, string[] options) 
        {
            Options = options;
            Title = title;
        }

        private string[] _options;
        public string[] Options
        {
            get => _options;
            set => SetProperty(ref _options, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _selectedItem;
        public string SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
