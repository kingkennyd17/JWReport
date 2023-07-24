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
    public partial class BibleStudiesPage : ContentPage
    {
        public BibleStudiesPage()
        {
            InitializeComponent();
            BindingContext = new BibleStudiesPageModel();
        }
    }
}