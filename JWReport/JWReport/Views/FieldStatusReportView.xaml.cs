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
    public partial class FieldStatusReportView : ContentView
    {
        private List<string> texts = new List<string>
        {
            "The row below shows info of your first time gfdtgftfgrfg",
            "You scheduled a visit with Emmanuel rygfgdrfr rtgtrg rygfgtefd yrgfdtrgf",
            "Your placements are added when you add first time thgrfg tyfgerfyg trftg",
            "Your videos are added when you add first time",
            "Do not add video again when you add first time",
            "Do not add placement again when you add first time",
            "The date and Question in Return Visit Table is for Next time"
            // Add more texts here as needed
        };
        //private TimeSpan _timeForText;
        //public TimeSpan TimeForText {
        //    get { return _timeForText; }
        //    set
        //    {
        //        if (_timeForText != value)
        //        {
        //            _timeForText = value;
        //            OnPropertyChanged("TimeForText");
        //        }
        //    }
        //}
        public int currentIndex { get; set; } = 0;

        public FieldStatusReportView()
        {
            InitializeComponent();
            movingTextLabel.Text = "";
            StartMovingTextAnimation();
        }

        private void StartMovingTextAnimation()
        {
            AnimateText();
        }

        private async void AnimateText()
        {
            double initialX = this.Width;

            // Reset the label to the initial position
            if (initialX < 50)
                initialX = 100.72;
            movingTextLabel.TranslationX = initialX;

            // Calculate the distance to move the label
            double distance = 0;
            if (movingTextLabel.Width < 50)
                distance = 100.72 + initialX;
            distance = movingTextLabel.Width + 1;

            // Calculate the duration based on the distance and a fixed speed (e.g., 100 pixels per second)
            int durationMilliseconds = (int)(distance * 20);

            // Create the animation to move the label from right to left
            await movingTextLabel.TranslateTo(-distance, 0, (uint)durationMilliseconds, Easing.Linear);
            currentIndex += 1;
            if (currentIndex > (texts.Count -1))
                currentIndex = 0;
            movingTextLabel.Text = texts[currentIndex];

            //TimeForText = TimeSpan.FromSeconds((durationMilliseconds * 5) / 20130);

            Device.StartTimer(TimeSpan.FromMilliseconds(1), () =>
            {
                AnimateText();
                return false; // True to repeat the timer
            });
        }
    }
}