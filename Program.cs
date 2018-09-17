using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FeedBackConsole
{
    class Program
    {
        static IZendeskClient<ZendeskTicketRequest> _client;
        //static IZendeskClient _zClient;
        static void Main(string[] args)

        {
            var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var ticket = new ZendeskTicketRequest
            {
                ticket = new Ticket
                {
                    Subject = $"Yey, this is a console ticket with id {Guid.NewGuid().ToString()}",
                    Description = $"blah blah blah",
                    Priority = Priority.Normal.ToString().ToLowerInvariant(),
                    Type = Type.Problem.ToString().ToLowerInvariant(),
                    Status = Status.New.ToString().ToLowerInvariant()
                }
            };
            _client = new ZendeskClient<ZendeskTicketRequest>(configuration);
            _client.PostTicketAsync(ticket).GetAwaiter().GetResult();
        }

    }




    public enum Priority
    {
        Urgent,
        Normal,
        Low,
        High

    }

    public enum Status
    {
        New,
        Open,
        Pending,
        Hold,
        Solved,
        Closed,
    }

    public enum Type
    {
        Problem,
        Incident,
        Question,
        Task
    }
}






