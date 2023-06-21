using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
    public class ContactModel
    {
        public ObservableCollection<Contacts> Contacts;

        public void GetContactsList()
        {
            Contacts = new ObservableCollection<Contacts>()
            {
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."},
                new Contacts(){ ProfilePhoto = "user2.jpg",Name="Amey",Status ="Home is where I am with you."},
                new Contacts(){ ProfilePhoto = "user3.jpg", Name="Higabana",Status="Anime is world"},
                new Contacts(){ProfilePhoto = "user4.jpg",Name="Jack",Status="Peace is Mission"},
                new Contacts(){ProfilePhoto="user5.jpg",Name="Ross",Status="Busy.."}


            };
        }
    }
}
