using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C6_Exercises
{
    public class GetQuoteResponseModel
    {
        [JsonProperty("quotes")]
        public List<Quote> Quotes { get;set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
    public class Quote
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quote")]
        public string Quotes { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}
