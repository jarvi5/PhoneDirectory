using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneDirectory.Models;

namespace PhoneDirectory.Services
{
    public interface IContactsService
    {
        Task<List<Contact>> GetContacts();
    }
}
