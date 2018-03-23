using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneDirectory.Core.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }
        private string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }
        private string _lastName;
        public string LastName { get => _lastName; set => SetProperty(ref _lastName, value); }
        private string _primaryPhone;
        public string PrimaryPhone { get => _primaryPhone; set => SetProperty(ref _primaryPhone, value); }
        private string _secundaryPhone;
        public string SecundaryPhone { get => _secundaryPhone; set => SetProperty(ref _secundaryPhone, value); }
        private string _address;
        public string Address { get => _address; set => SetProperty(ref _address, value); }
        private DateTime _birthdate;
        public DateTime Birthdate { get => _birthdate; set => SetProperty(ref _birthdate, value); }
        private string _image;
        public string Image { get => _image; set => SetProperty(ref _image, value); }


        public Contact()
        {
            Id = -1;
            FirstName = null;
            LastName = null;
            PrimaryPhone = null;
            SecundaryPhone = null;
            Address = null;
            Birthdate = new DateTime();
            Image = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
