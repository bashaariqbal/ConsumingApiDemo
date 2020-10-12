using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsumingWebAPIDemo
{
    class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string Error { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
    }
}
