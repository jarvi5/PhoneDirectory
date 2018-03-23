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


        private IMvxCommand _onEditButtonClick;
        public IMvxCommand OnEditButtonClick =>
        _onEditButtonClick = _onEditButtonClick ?? new MvxCommand(EditContact);

        private async void EditContact()
        {
            Contact = await _navigationService.Navigate<CreateEditContactViewModel, Contact, Contact>(Contact);
        }

        private IMvxCommand _onBackButtonClick;
        public IMvxCommand OnBackButtonClick =>
        _onBackButtonClick = _onBackButtonClick ?? new MvxCommand(GoBack);

        private async void GoBack()
        {
            await _navigationService.Close(this);
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
