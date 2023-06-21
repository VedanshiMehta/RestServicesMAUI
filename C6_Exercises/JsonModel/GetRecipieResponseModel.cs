using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetRecipieResponseModel
    {
        [JsonProperty("recipes")]
        public List<Recipe> Recipes { get; set; }
    }
    public class Recipe
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("time_to_prepare")]
        public string TimeToPrepare { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}
