using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FeedBackConsole
{
    public class ZendeskClient<T> : IZendeskClient<T> where T : class
    {
        private readonly HttpClient _client = new HttpClient();

        public ZendeskClient(IConfigurationRoot configuration)
        {
            var credentials = new UTF8Encoding().GetBytes($"{configuration.GetSection("user").Value}:{configuration.GetSection("pwd").Value}");
            _client.BaseAddress = new Uri($"{configuration.GetSection("base_url").Value}");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
        }
        public async Task PostTicketAsync(T ticket)
        {
            if (ticket == null)
            {
                throw new System.ArgumentNullException(nameof(ticket));
            }

            try
            {
                var url = await CreateTicketAsync(ticket);
                Console.WriteLine($"Created at {url}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }


        async Task<Uri> CreateTicketAsync(T ticket)
        {
            var response = await _client.PostAsJsonAsync("api/v2/tickets.json", ticket);
            Console.WriteLine(response);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;

        }
    }

}