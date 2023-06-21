using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class Message
    {
        public ImageSource ProfilePhoto { get; set; }
        public bool IsUnReadMessage { get; set; }

        public string Name { get; set; }
        public string MessageSent { get; set; }


        public string UnreadMessage { get; set; }

        public string Time { get; set; }
    }
}
