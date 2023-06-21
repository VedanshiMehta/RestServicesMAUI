using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetActivitesEndPoint
    {
        public ActivitiesRequestModel ActivitiesRequest { get; set; }
        public int Id { get; set; }
     
        public async Task<HttpResponseMessage> ExecuteActivityAsync()
        {
            return await RestService.For<IActivitiesApi>("https://fakerestapi.azurewebsites.net/api/v1").GetActivitesList();
        }
        public async Task<HttpResponseMessage> AddActivityAsync()
        {
            return await RestService.For<IActivitiesApi>("https://fakerestapi.azurewebsites.net/api/v1").AddActivity(ActivitiesRequest);
        }
        public async Task<HttpResponseMessage> DeleteActivityAsync()
        {
            return await RestService.For<IActivitiesApi>("https://fakerestapi.azurewebsites.net/api/v1").DeleteActivity(Id);
        }
        public async Task<HttpResponseMessage> UpdateActivityAsync()
        {
            return await RestService.For<IActivitiesApi>("https://fakerestapi.azurewebsites.net/api/v1").UpdateActivity(ActivitiesRequest,Id);
        }
    }
}
