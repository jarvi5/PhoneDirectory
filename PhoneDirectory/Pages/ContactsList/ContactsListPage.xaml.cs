using MvvmCross.Forms.Views;
using PhoneDirectory.Core.ViewModels;
using PhoneDirectory.Core.Models;
using Xamarin.Forms;

namespace PhoneDirectory.Core.Pages
{
    public partial class ContactsListPage : MvxContentPage<ContactsListViewModel>
    {
        public ContactsListPage()
        {
            InitializeComponent();
        }

        async void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ContactsListViewModel contactsViewModel = (ContactsListViewModel)BindingContext.DataContext;
            Contact contact = (Contact)e.SelectedItem;
            await contactsViewModel.ShowContactDetail(contact);
        }
    }
}
