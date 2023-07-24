using JWReport.PageModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace JWReport.ViewModels.Buttons
{
    public class ButtonModel : ExtendedBindableObject
    {
        string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        bool _isVisible;
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        ICommand _command;
        private string v;
        private Action onClockInOutAction;

        public ICommand Command
        {
            get => _command;
            set => SetProperty(ref _command, value);
        }

        private string _parameter;
        public string Parameter
        {
            get => _parameter;
            set => SetProperty(ref _parameter, value);
        }

        public ButtonModel(string title,ICommand command, bool isVisible = true, bool isEnable = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnabled = isEnable;
        }

        public ButtonModel(string text, Action action, bool isVisible, bool isEnabled = true)
        {
            Text = text;
            Command = new Command(action);
            IsVisible = isVisible;
            IsEnabled = isEnabled;
        }

        public ButtonModel(string title, ICommand command, string parameter, bool isVisible = true, bool isEnable = true)
        {
            Text = title;
            Command = command;
            IsVisible = isVisible;
            IsEnabled = isEnable;
            Parameter = parameter;
        }

        public ButtonModel(string text, Action<string> action, string parameter, bool isVisible = true, bool isEnabled = true)
        {
            Text = text;
            Command = new Command<string>(action);
            IsVisible = isVisible;
            IsEnabled = isEnabled;
            Parameter = parameter;
        }

        public ButtonModel(string v, Action onClockInOutAction)
        {
            this.v = v;
            this.onClockInOutAction = onClockInOutAction;
        }
    }
}
