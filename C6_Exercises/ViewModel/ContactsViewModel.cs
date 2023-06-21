using C6_Exercises.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.ViewModel
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private ContactModel _contactModel;
        private ObservableCollection<Contacts> _contactsList;

        public ObservableCollection<Contacts> ShowContactList { get => _contactsList; set { _contactsList = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public ContactsViewModel()
        {

            _contactModel = new ContactModel();
            _contactModel.GetContactsList();
            ShowContactList = _contactModel.Contacts;
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
