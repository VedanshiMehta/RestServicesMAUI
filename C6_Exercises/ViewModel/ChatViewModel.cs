using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C6_Exercises.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private ChatModel _chatModel;
        private ObservableCollection<Message> _messageList;

        public ObservableCollection<Message> ShowMessageList { get => _messageList; set { _messageList = value; OnPropertyChanged(); } }

       
        public event PropertyChangedEventHandler PropertyChanged;
        public ChatViewModel()
        {
            
            _chatModel = new ChatModel();
            _chatModel.GetCategoryList();
            ShowMessageList = _chatModel.Messages;
        }


        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
