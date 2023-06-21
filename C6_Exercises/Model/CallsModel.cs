using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Model
{
    class CallsModel
    {
        public ObservableCollection<Calls> CallsList;
        public void GetCallsList()
        {
            CallsList = new ObservableCollection<Calls>()
            {
                new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                 new Calls(){ ProfilePhoto = "user2.jpg",Name="Amey",CallSigns="incomingcall.png",Time="April 6, 7:42 PM",CallIcon ="call.png"},
                new Calls(){ ProfilePhoto = "user3.jpg", Name="Higabana",CallSigns="outgoingcall.png",Time="April 6, 9:43 AM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto = "user4.jpg",Name="Jack",CallSigns="incomingcall.png",Time="March 25, 12:48 PM",CallIcon ="call.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},
                new Calls(){ProfilePhoto="user5.jpg",Name ="Ross",CallSigns="outgoingcall.png",Time="March 24, 6:57 PM",CallIcon ="videocamera.png"},

            };
        }
    }
}
