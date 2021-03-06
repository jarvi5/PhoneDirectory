using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PhoneDirectory.Core.Models;
using PhoneDirectory.Core.Services;
using Xamarin.Forms;

namespace PhoneDirectory.Core.ViewModels
{
    public class ContactsListViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        private FirebaseContactsService _firebaseContactsService;

        private List<Contact> _contacts;
        public List<Contact> Contacts
        {
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private IMvxCommand<Contact> _onPhoneClick;
        public IMvxCommand<Contact> OnPhoneClick =>
        _onPhoneClick = _onPhoneClick ?? new MvxCommand<Contact>(MakeCall);

        private async void MakeCall(Contact contact)
        {
            if (await Application.Current.MainPage.DisplayAlert("Dial a Number", "Would you like to call " + contact.PrimaryPhone + "?", "Yes", "No"))
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                    await dialer.DialAsync(contact.PrimaryPhone);
            }
        }

        public async Task ShowContactDetail(Contact contact)
        {
            await _navigationService.Navigate<ContactDetailViewModel, Contact>(contact);
        }

        public ContactsListViewModel(IMvxNavigationService navigationService)
        {
            _firebaseContactsService = new FirebaseContactsService();
            Title = "Contacts List";
            _navigationService = navigationService;
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

		public async override void ViewAppearing()
		{
            Contacts = await _firebaseContactsService.GetContacts();
            base.ViewAppearing();
		}


	}
}
