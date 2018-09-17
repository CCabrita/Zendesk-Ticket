using Newtonsoft.Json;

namespace FeedBackConsole
{
    public class ZendeskTicketRequest
    {
        [JsonProperty(PropertyName = "ticket")]
        public Ticket ticket { get; set; }
    }
}






