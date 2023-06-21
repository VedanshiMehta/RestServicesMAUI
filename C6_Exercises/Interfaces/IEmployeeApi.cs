using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public interface IEmployeeApi
    {
        [Get("/users")]
        Task<HttpResponseMessage> GetEmployeDetails();

        [Post("/users")]
        Task<HttpResponseMessage> AddEmployeDetails([Body] EmployeeRequestModel employeeRequestModel);

        [Put("/users/{id}")]
        Task<HttpResponseMessage> UpdateEmployeDetails([Body] EmployeeRequestModel employeeRequestModel,int id);

        [Delete("/users/{id}")]
        Task<HttpResponseMessage> DeleteEmployeeDetails(int id);
    }
}
