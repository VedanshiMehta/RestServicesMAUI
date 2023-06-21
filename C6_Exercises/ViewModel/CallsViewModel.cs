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
    public class CallsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CallsModel _callsModel;
        private ObservableCollection<Calls> _callsList;

      

        public ObservableCollection<Calls> ShowCallsList { get => _callsList; set { _callsList = value; OnPropertyChanged(); } }
        public CallsViewModel()
        {
            _callsModel = new CallsModel();
            _callsModel.GetCallsList();
            ShowCallsList = _callsModel.CallsList;
        }
        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
