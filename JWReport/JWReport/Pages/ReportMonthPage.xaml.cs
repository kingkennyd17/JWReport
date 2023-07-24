﻿using JWReport.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JWReport.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportMonthPage : ContentPage
    {
        public ReportMonthPage()
        {
            InitializeComponent();
            BindingContext = new ReportMonthPageModel();
        }
    }
}