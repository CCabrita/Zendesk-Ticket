using Newtonsoft.Json;

namespace FeedBackConsole
{
    public class Ticket
    {
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }//mandatory

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public string Priority { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "collaborators")]
        public string Collaborators { get; set; }

    }
}
