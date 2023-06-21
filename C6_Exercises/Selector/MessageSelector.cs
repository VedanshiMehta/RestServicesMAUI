using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.Selector
{
    class MessageSelector : DataTemplateSelector
    {
        public DataTemplate ReadMessage { get; set; }
        public DataTemplate UnreadMessage { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = (Message)item;
            return (message.IsUnReadMessage) ? UnreadMessage : ReadMessage;
        }
    }
}
