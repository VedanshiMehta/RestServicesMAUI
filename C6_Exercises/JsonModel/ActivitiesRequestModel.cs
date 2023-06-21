using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class ActivitiesRequestModel
    {
        [JsonProperty("id")]
        public int Id {get; set;}

        [JsonProperty("title")]
        public string Title { get; set;}

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set;}

        [JsonProperty("completed")]
        public bool Completed { get; set;}
    }
}
