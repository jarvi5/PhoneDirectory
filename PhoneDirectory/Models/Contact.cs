using System;
namespace PhoneDirectory.Core.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhone { get; set; }
        public string SecundaryPhone { get; set; }
        public string Address { get; set; }
        public DateTime Bithdate { get; set; }
        public string Image { get; set; }
    }
}
