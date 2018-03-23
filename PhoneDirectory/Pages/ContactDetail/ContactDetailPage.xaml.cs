using MvvmCross.Forms.Views;
using PhoneDirectory.Core.ViewModels;
using Xamarin.Forms;

namespace PhoneDirectory.Core.Pages
{
    public partial class ContactDetailPage : MvxContentPage<ContactDetailViewModel>
    {
        public ContactDetailPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }
    }
}
