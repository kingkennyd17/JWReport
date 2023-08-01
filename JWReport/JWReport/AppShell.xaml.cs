using System;
using System.Collections.Generic;
using System.ComponentModel;
using JWReport.Pages;
using JWReport.ViewModels;
using JWReport.Views;
using Xamarin.Forms;

namespace JWReport
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        Person person;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(FieldPage), typeof(FieldPage));
            Routing.RegisterRoute(nameof(LaunchPage), typeof(LaunchPage));
            Routing.RegisterRoute(nameof(WelcomePrivilegePage), typeof(WelcomePrivilegePage));
            Routing.RegisterRoute(nameof(WelcomeProfilePage), typeof(WelcomeProfilePage));
            Routing.RegisterRoute(nameof(WelcomeGroupOverseerPage), typeof(WelcomeGroupOverseerPage));
            person = new Person();
            this.BindingContext = person;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            person.Changed = !person.Changed;
            if (person.Changed)
            {
                person.ReportBgColor = "Gray";
            }
        }
    }

    public class Person : INotifyPropertyChanged
    { //ReportBgColor

        bool _changed = false;
        public bool Changed
        {
            get
            {
                return _changed;
            }

            set
            {
                if (_changed != value)
                {
                    _changed = value;
                    OnPropertyChanged("Changed");

                }
            }

        }
        string _reportBgColor = "Red";
        public string ReportBgColor
        {
            get
            {
                return _reportBgColor;
            }

            set
            {
                if (_reportBgColor != value)
                {
                    _reportBgColor = value;
                    OnPropertyChanged("ReportBgColor");

                }
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
