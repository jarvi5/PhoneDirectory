using System.Threading.Tasks;

namespace PhoneDirectory.Services
{
    public interface IDialer
    {
        Task<bool> DialAsync(string phonenumber);
    }
}
