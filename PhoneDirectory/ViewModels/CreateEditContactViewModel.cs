using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PhoneDirectory.Core.Models;
using PhoneDirectory.Core.Services;
using Xamarin.Forms;

namespace PhoneDirectory.Core.ViewModels
{
    public class CreateEditContactViewModel : MvxViewModel<Contact, Contact>
    {
        private readonly IMvxNavigationService _navigationService;
        private FirebaseContactsService _firebaseContactsService;

        private Contact _contact;
        public Contact Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private Contact _newContact;
        public Contact NewContact
        {
            get => _newContact;
            set => SetProperty(ref _newContact, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private IMvxAsyncCommand _onSaveButtonClick;
        public IMvxAsyncCommand OnSaveButtonClick =>
        _onSaveButtonClick = _onSaveButtonClick ?? new MvxAsyncCommand(SaveContact);

        private async Task SaveContact()
        {
            if (isValidContact(NewContact))
            {
                await _firebaseContactsService.EditContact(NewContact);
                await _navigationService.Close(this, NewContact);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Contact", "Fill all required fields", "Accept");
            }
        }

        private IMvxAsyncCommand _onCancelButtonClick;
        public IMvxAsyncCommand OnCancelButtonClick =>
        _onCancelButtonClick = _onCancelButtonClick ?? new MvxAsyncCommand(Dismiss);

        public async Task Dismiss()
        {
            bool close = await Application.Current.MainPage.DisplayAlert("Warning", "Changes will be lost", "Accept", "Cancel");
            if (close)
            {
                await _navigationService.Close(this, Contact);
            }
        }

        public CreateEditContactViewModel(IMvxNavigationService navigationService)
        {
            Title = "Contact Detail";
            _firebaseContactsService = new FirebaseContactsService();
            _navigationService = navigationService;
        }

        public override void Prepare(Contact parameter)
        {
            if(parameter != null)
            {
                NewContact = new Contact
                {
                    FirstName = parameter.FirstName,
                    LastName = parameter.LastName,
                    PrimaryPhone = parameter.PrimaryPhone,
                    SecundaryPhone = parameter.SecundaryPhone,
                    Address = parameter.Address,
                    Birthdate = parameter.Birthdate
                };
            }
            else
            {
                NewContact = null;
            }
            Contact = parameter;
        }

        private bool isValidContact(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.FirstName)
                          && !string.IsNullOrEmpty(contact.LastName)
                          && !string.IsNullOrEmpty(contact.PrimaryPhone);
        }
    }
}
