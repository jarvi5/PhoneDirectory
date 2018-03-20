using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneDirectory.Core.Models;

namespace PhoneDirectory.Core.Services
{
    public interface IContactsService
    {
        Task<List<Contact>> GetContacts();
    }
}
