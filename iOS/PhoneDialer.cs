using System.Threading.Tasks;
using Foundation; 
using PhoneDirectory.iOS;
using PhoneDirectory.Core.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]
namespace PhoneDirectory.iOS
{
    public class PhoneDialer : IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            return Task.FromResult(
                UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number))
            );
        }
    }
}
