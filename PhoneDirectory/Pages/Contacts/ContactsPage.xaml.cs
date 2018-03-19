using System;
using System.Collections.Generic;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using PhoneDirectory.Core.ViewModels;
using Xamarin.Forms;

namespace PhoneDirectory.Core.Pages
{
    public partial class ContactsPage : MvxContentPage<ContactsViewModel>
    {
        public ContactsPage()
        {
            InitializeComponent();
        }
    }
}
