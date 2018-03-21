using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneDirectory.Core.Models;

namespace PhoneDirectory.Core.Services
{
    public class FirebaseContactsService : IContactsService
    {
        HttpClient _httpClient;
        string _baseUrl;

        public FirebaseContactsService()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://phonedirectory-8eaff.firebaseio.com/";
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<List<Contact>> GetContacts()
        {
            string contacts = await _httpClient.GetStringAsync(_baseUrl + "Contacts.json");
            return JsonConvert.DeserializeObject<List<Contact>>(contacts);
        }

        public async Task<bool> CreateContact(Contact contact)
        {
            int index = await GetIndex(contact);
            string stringContact = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(stringContact);
            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl + "Contacts.json", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditContact(Contact contact)
        {
            int index = await GetIndex(contact);
            string stringContact = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(stringContact);
            HttpResponseMessage response = await _httpClient.PutAsync(_baseUrl + "Contacts/"+ index +".json", content);
            return response.IsSuccessStatusCode;
        }

        private async Task<int> GetIndex(Contact contact)
        {
            List<Contact> contacts = await GetContacts();
            return contacts.FindIndex((obj) => obj.PrimaryPhone == contact.PrimaryPhone);
        }
    }
}
