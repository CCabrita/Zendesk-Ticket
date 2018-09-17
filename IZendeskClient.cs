using System.Threading.Tasks;

namespace FeedBackConsole
{
    public interface IZendeskClient<T> where T : class
    {
        Task PostTicketAsync(T ticket);
    }
}