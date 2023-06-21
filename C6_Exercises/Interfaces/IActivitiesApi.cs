using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public interface IActivitiesApi
    {
        [Get("/Activities")]
        Task<HttpResponseMessage> GetActivitesList();

        [Post("/Activities")]
        Task<HttpResponseMessage> AddActivity([Body] ActivitiesRequestModel activitiesRequestModel);

        [Delete("/Activities/{id}")]
        Task<HttpResponseMessage> DeleteActivity(int id);

        [Put("/Activities/{id}")]
        Task<HttpResponseMessage> UpdateActivity([Body] ActivitiesRequestModel activitiesRequestModel, int id);
    }
}
