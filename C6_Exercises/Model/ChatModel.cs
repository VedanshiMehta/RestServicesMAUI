using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class ChatModel
    {

        public ObservableCollection<Message> Messages { get; set; }

        public void GetCategoryList()
        {
            Messages = new ObservableCollection<Message>()
            {
                new Message(){ ProfilePhoto = "user2.jpg",Name="Amey",MessageSent="Hey, hi how are you?",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "12:00"}, 
                new Message(){ ProfilePhoto = "user4.jpg",Name="Jack",MessageSent="Good evening!...",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "18:00"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Happy Hour",MessageSent="Keep Smiling...",IsUnReadMessage = true,UnreadMessage = "2",  Time = "YESTERDAY"},
                new Message(){ ProfilePhoto = "user2.jpg",Name="Joey",MessageSent="How you doin?.....",IsUnReadMessage = true,UnreadMessage = "2",  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user3.jpg",Name="Justice League",MessageSent="Good morning robin..",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Ross",MessageSent="I am dinosaur guy",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                 new Message(){ ProfilePhoto = "user2.jpg",Name="Amey",MessageSent="Hey, hi how are you?",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "12:00"},
                new Message(){ ProfilePhoto = "user4.jpg",Name="Jack",MessageSent="Good evening!...",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "18:00"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Happy Hour",MessageSent="Keep Smiling...",IsUnReadMessage = true,UnreadMessage = "2",  Time = "YESTERDAY"},
                new Message(){ ProfilePhoto = "user2.jpg",Name="Joey",MessageSent="How you doin?.....",IsUnReadMessage = true,UnreadMessage = "2",  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user3.jpg",Name="Justice League",MessageSent="Good morning robin..",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Ross",MessageSent="I am dinosaur guy",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                 new Message(){ ProfilePhoto = "user2.jpg",Name="Amey",MessageSent="Hey, hi how are you?",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "12:00"},
                new Message(){ ProfilePhoto = "user4.jpg",Name="Jack",MessageSent="Good evening!...",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "18:00"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Happy Hour",MessageSent="Keep Smiling...",IsUnReadMessage = true,UnreadMessage = "2",  Time = "YESTERDAY"},
                new Message(){ ProfilePhoto = "user2.jpg",Name="Joey",MessageSent="How you doin?.....",IsUnReadMessage = true,UnreadMessage = "2",  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user3.jpg",Name="Justice League",MessageSent="Good morning robin..",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Ross",MessageSent="I am dinosaur guy",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                 new Message(){ ProfilePhoto = "user2.jpg",Name="Amey",MessageSent="Hey, hi how are you?",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "12:00"},
                new Message(){ ProfilePhoto = "user4.jpg",Name="Jack",MessageSent="Good evening!...",IsUnReadMessage = false,UnreadMessage = string.Empty, Time = "18:00"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Happy Hour",MessageSent="Keep Smiling...",IsUnReadMessage = true,UnreadMessage = "2",  Time = "YESTERDAY"},
                new Message(){ ProfilePhoto = "user2.jpg",Name="Joey",MessageSent="How you doin?.....",IsUnReadMessage = true,UnreadMessage = "2",  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user3.jpg",Name="Justice League",MessageSent="Good morning robin..",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},
                new Message(){ ProfilePhoto = "user5.jpg",Name="Ross",MessageSent="I am dinosaur guy",IsUnReadMessage = false,UnreadMessage = string.Empty,  Time = "FRIDAY"},

            };

          

        }

    }
}
