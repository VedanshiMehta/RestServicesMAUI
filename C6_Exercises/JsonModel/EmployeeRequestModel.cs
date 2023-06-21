using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
     public class EmployeeRequestModel
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string Avatar { get; set; }

        [JsonIgnore]
        public int Id { get; set; }
    }
}
