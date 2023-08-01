using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace JWReport.Services.Helpers
{
    public class PhoneDialerHelper
    {
        public static void MakePhoneCall(string phoneNumber)
        {
            try
            {
                PhoneDialer.Open(phoneNumber);
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                // Phone dialer is not supported on this device.
                // Handle the error or display a message to the user.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Other error occurred while making the phone call.
                // Handle the error or display a message to the user.
            }
        }
    }

}
