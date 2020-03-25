using System.Threading.Tasks;

namespace RealTimeChat.Interfaces
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
