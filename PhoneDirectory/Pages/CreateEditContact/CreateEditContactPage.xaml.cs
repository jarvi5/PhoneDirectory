using MvvmCross.Forms.Views;
using PhoneDirectory.Core.Models;
using PhoneDirectory.Core.ViewModels;
using Xamarin.Forms;

namespace PhoneDirectory.Core.Pages
{
    public partial class CreateEditContactPage : MvxContentPage<CreateEditContactViewModel>
    {
        public CreateEditContactPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
		{
            CreateEditContactViewModel createEditContactViewModel = (CreateEditContactViewModel)BindingContext.DataContext;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await createEditContactViewModel.Dismiss();
            });
            return true;
		}
	}
}
