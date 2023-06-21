using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises.EndPoint
{
    public class GetEmployeesEndPoint
    {
        public EmployeeRequestModel Employee { get; set; }
        public int Id { get; set; } 
        public async Task<HttpResponseMessage> GetEmployeeDetailsAsync()
        {
            return await RestService.For<IEmployeeApi>("https://reqres.in/api").GetEmployeDetails();
        }
        public async Task<HttpResponseMessage> AddEmployeeDetailsAsync()
        {
            return await RestService.For<IEmployeeApi>("https://reqres.in/api").AddEmployeDetails(Employee);
        }
        public async Task<HttpResponseMessage> UpdateEmployeeDetailsAsync()
        {
            return await RestService.For<IEmployeeApi>("https://reqres.in/api").UpdateEmployeDetails(Employee,Id);
        }
        public async Task<HttpResponseMessage> DeleteEmployeeDetailsAsync()
        {
            return await RestService.For<IEmployeeApi>("https://reqres.in/api").DeleteEmployeeDetails(Id);
        }
    }
}
