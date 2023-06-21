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
    public class GetQuotesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Quote> _quotes;
        private GetQuoteModel _model;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isLoading = true;
        private bool _isVisibleCollectionView;


        public ObservableCollection<Quote> QuotesList { get => _quotes; set { _quotes = value;OnPropertyChanged(); } }
        public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }
        public bool IsVisibleCollectionView { get => _isVisibleCollectionView; set { _isVisibleCollectionView = value; OnPropertyChanged(); } }


        public GetQuotesViewModel()
        {
            _model = new GetQuoteModel();
            _model.IsLoading = IsLoading;
            _ = GetQuotesList();
        }

        private async Task GetQuotesList()
        {
            await _model.GetQuotesListAsync();
            QuotesList = _model.Quotes;
            IsLoading = _model.IsLoading;
            IsVisibleCollectionView = _model.IsVisibleCollectionView;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
