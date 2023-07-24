using JWReport.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWReport.ViewModels
{
    public class DateEntryViewModel : ExtendedBindableObject
    {
        private string _format;
        public string Format
        {
            get => _format;
            set => SetProperty(ref _format, value);
        }

        private string _selectedDate;
        public string SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private string _placeholder;
        public string Placeholder
        {
            get => _placeholder;
            set => SetProperty(ref _placeholder, value);
        }

        public DateEntryViewModel(string format, string placeholder)
        {
            Format = format;
            Placeholder = placeholder;
        }
    }
}
