using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneDirectory.Models;

namespace PhoneDirectory.Services
{
    public class FirebaseContactsService : IContactsService
    {
        HttpClient HttpClient { get; set; }

        public FirebaseContactsService()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Contact>> GetContacts()
        {
            string contacts = await HttpClient.GetStringAsync("https://phonedirectory-8eaff.firebaseio.com/Contacts.json");
            return JsonConvert.DeserializeObject<List<Contact>>(contacts);
        }
    }
}
