using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C6_Exercises.ViewModel
{
    public class GetRandomQuotesViewModel : INotifyPropertyChanged
    {
        private string _quote { get; set; }
        private string _authorName { get; set; }
        private GetRandomModel _getRandomModel;

       

        public event PropertyChangedEventHandler PropertyChanged;
        public string Quote { get => _quote; set { _quote = value;OnPropertyChanged(); } }
        public string AuthorName { get => _authorName; set { _authorName = value;OnPropertyChanged(); } }
        public ICommand GetQuote {  get; set; }
        public GetRandomQuotesViewModel()
        {
            GetQuote = new Command(GetRandomQuotes);
            _getRandomModel = new GetRandomModel();
        }

        private async void GetRandomQuotes()
        {
           await _getRandomModel.GetRandomQuoteAsync();
           Quote = _getRandomModel.Quote;
           AuthorName = _getRandomModel.AuthorName;
        }

        public void OnPropertyChanged([CallerMemberName]string propertyName ="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
