using System.Threading.Tasks;

namespace PhoneDirectory.Core.Services
{
    public interface IDialer
    {
        Task<bool> DialAsync(string phonenumber);
    }
}
