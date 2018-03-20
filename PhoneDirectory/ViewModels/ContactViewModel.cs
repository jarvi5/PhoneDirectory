using MvvmCross.Core.ViewModels;
using PhoneDirectory.Core.Models;

namespace PhoneDirectory.Core.ViewModels
{
    public class ContactViewModel : MvxViewModel<Contact>
    {
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

        public override void Prepare(Contact parameter)
        {
            _contact = parameter;
            Title = "Contact Detail";
        }
    }
}
