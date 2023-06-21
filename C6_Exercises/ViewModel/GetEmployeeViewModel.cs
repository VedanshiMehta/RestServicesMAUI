using C6_Exercises.Model;
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
    public class GetEmployeeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Datum> _employeeList;
        public event PropertyChangedEventHandler PropertyChanged;
        private GetEmployeeModel _model;
        private DeleteEmployeeModel _deleteEmployeeModel;
        private bool _isLoading = true;
        private bool _isVisibleCollectionView;

        public bool IsLoading { get => _isLoading; set { _isLoading = value; OnPropertyChanged(); } }
        public bool IsVisibleCollectionView { get => _isVisibleCollectionView; set { _isVisibleCollectionView = value; OnPropertyChanged(); } }
        public ObservableCollection<Datum> EmployeeList { get => _employeeList; set { _employeeList = value; OnPropertyChanged(); } }
        public event EventHandler<UpdateEmployeeDataEventArgs> UpdateEmployeeData;
        public event EventHandler<Result> DeleteEmployeeData;
        public ICommand UpdateEmployee { get; private set; }
        public ICommand DeleteEmployee { get; private set; }
        public GetEmployeeViewModel()
        {
            UpdateEmployee = new Command<Datum>(GetUpdatedDetails);
            DeleteEmployee = new Command<Datum>(DeleteEmployeeDetails);
            _model = new GetEmployeeModel();
            _deleteEmployeeModel = new DeleteEmployeeModel();
            _model.IsLoading = IsLoading;
            _ = GetEmployeeDetails();

        }

        private async void DeleteEmployeeDetails(Datum employeeData)
        {
            _deleteEmployeeModel.Id = employeeData.Id;
            var result = await _deleteEmployeeModel.DeleteEmployeeAsync();
            DeleteEmployeeData?.Invoke(this, result);
            
        }

        private void GetUpdatedDetails(Datum employeeData)
        {
            UpdateEmployeeData?.Invoke(this, new UpdateEmployeeDataEventArgs()
            {
                Id= employeeData.Id,
                FirstName= employeeData.FirstName,
                LastName= employeeData.LastName,
                Avtar = employeeData.Avatar,
                Email = employeeData.Email,
                
            });
        }

       

        public async Task GetEmployeeDetails()
        {

            await _model.GetEmployeeList();
            EmployeeList = _model.EmployeeList;
            IsLoading = _model.IsLoading;
            IsVisibleCollectionView = _model.IsVisibleCollectionView;


        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class UpdateEmployeeDataEventArgs : EventArgs
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Avtar { get; set; }   
        public string Email { get; set; }
    }
}
