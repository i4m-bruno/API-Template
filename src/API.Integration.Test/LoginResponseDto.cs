using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Integration.Test
{
    public class LoginResponseDto
    {
        [JsonProperty("authenticated")]
        public bool authenticated { get; set; }

        [JsonProperty("created")]
        public DateTime created { get; set; }

        [JsonProperty("expires")]
        public DateTime expires { get; set; }

        [JsonProperty("accessToken")]
        public string accessToken { get; set; }

        [JsonProperty("userName")]
        public string userName { get; set; }

        [JsonProperty("mail")]
        public string mail { get; set; }

        [JsonProperty("message")]
        public string message { get; set; }
    }
}
