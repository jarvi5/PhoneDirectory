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

        private bool _busy;
        public bool Busy
        {
            get => _busy;
            set => SetProperty(ref _busy, value);
        }

        private bool _notBusy;
        public bool NotBusy
        {
            get => _notBusy;
            set => SetProperty(ref _notBusy, value);
        }

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

        private IMvxCommand _onSaveButtonClick;
        public IMvxCommand OnSaveButtonClick =>
        _onSaveButtonClick = _onSaveButtonClick ?? new MvxCommand(SaveContact);

        private async void SaveContact()
        {
            if (isValidContact(NewContact))
            {
                Busy = true;
                NotBusy = !Busy;
                await _firebaseContactsService.CreateEditContact(NewContact);
                await _navigationService.Close(this, NewContact);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Invalid Contact", "Fill all required fields", "Accept");
            }
        }

        private IMvxCommand _onCancelButtonClick;
        public IMvxCommand OnCancelButtonClick =>
        _onCancelButtonClick = _onCancelButtonClick ?? new MvxCommand(Dismiss);

        public async void Dismiss()
        {
            bool close = await Application.Current.MainPage.DisplayAlert("Warning", "Changes will be lost", "Accept", "Cancel");
            if (close)
            {
                await _navigationService.Close(this, Contact);
            }
        }

        public CreateEditContactViewModel(IMvxNavigationService navigationService)
        {
            _firebaseContactsService = new FirebaseContactsService();
            Busy = false;
            NotBusy = !Busy;
            _navigationService = navigationService;
        }

        public override void Prepare(Contact parameter)
        {
            if(parameter != null)
            {
                NewContact = new Contact
                {
                    Id = parameter.Id,
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
                NewContact = new Contact();
            }
            Contact = parameter;
            Title = Contact == null ? "Create Contact" : "Edit Contact";
        }

        private bool isValidContact(Contact contact)
        {
            if (contact == null) return false;
            return !string.IsNullOrEmpty(contact.FirstName)
                          && !string.IsNullOrEmpty(contact.LastName)
                          && !string.IsNullOrEmpty(contact.PrimaryPhone);
        }
    }
}
