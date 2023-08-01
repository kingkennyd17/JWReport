using JWReport.PageModels.Base;
using JWReport.Services.Helpers;
using JWReport.ViewModels.Buttons;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JWReport.ViewModels
{
    public class PhoneMessageIconViewModel : ExtendedBindableObject
    {
        public Command PhoneCallCommand { get; }
        public Command SendMessageCommand { get; }
        public PhoneMessageIconViewModel(string phoneNumber)
        {
            PhoneNumber = phoneNumber;

            PhoneCallCommand = new Command(PhoneCall);
            SendMessageCommand = new Command(SendMessage);
        }

        private void SendMessage(object obj)
        {
            var messageSender = CrossMessaging.Current.SmsMessenger;
            if (messageSender.CanSendSms)
                messageSender.SendSms(PhoneNumber);
        }

        private void PhoneCall(object obj)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall || true)
                PhoneDialerHelper.MakePhoneCall(PhoneNumber);
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }
    }
}
