using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using PhoneDirectory.Core.Models;

namespace PhoneDirectory.Core.ViewModels
{
    public class ContactDetailViewModel : MvxViewModel<Contact>
    {
        private readonly IMvxNavigationService _navigationService;

        private Contact _contact;
        public Contact Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        private IMvxAsyncCommand _onEditButtonClick;
        public IMvxAsyncCommand OnEditButtonClick =>
        _onEditButtonClick = _onEditButtonClick ?? new MvxAsyncCommand(SaveContact);

        private async Task SaveContact()
        {
            Contact = await _navigationService.Navigate<CreateEditContactViewModel, Contact, Contact>(Contact);
        }

        public ContactDetailViewModel(IMvxNavigationService navigationService)
        {
            Title = "Contact Detail";
            _navigationService = navigationService;
        }

        public override void Prepare(Contact parameter)
        {
            Contact = parameter;
        }
    }
}
