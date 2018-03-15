using System;
using System.Collections.Generic;
using MvvmCross.Forms.Views;
using PhoneDirectory.Core.ViewModels;
using Xamarin.Forms;

namespace PhoneDirectory.Core.Pages
{
    public partial class MainPage : MvxContentPage<MainViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
