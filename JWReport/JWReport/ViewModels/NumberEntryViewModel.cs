using JWReport.PageModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace JWReport.ViewModels
{
    public class NumberEntryViewModel : ExtendedBindableObject
    {
        private int _number;
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }

        private bool _hide;
        public bool Hide
        {
            get => _hide;
            set => SetProperty(ref _hide, value);
        }

        public Command IncrementCommand { get; }
        public Command DecrementCommand { get; }

        public NumberEntryViewModel(int number)
        {
            Number = number;
            Hide = false;

            IncrementCommand = new Command(Increment);
            DecrementCommand = new Command(Decrement);
        }


        public NumberEntryViewModel(int number, bool hide, Action increaseAction, Action decreaseAction)
        {
            Number = number;
            Hide = hide;

            IncrementCommand = new Command(increaseAction);
            DecrementCommand = new Command(decreaseAction);
        }

        public void Increment()
        {
            Number++;
        }

        public void Decrement()
        {
            Number--;
        }
    }
}
