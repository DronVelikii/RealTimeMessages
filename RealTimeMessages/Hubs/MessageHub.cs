using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeMessages.Services;

namespace RealTimeMessages.Hubs
{
    /// <summary>
    /// Хаб для получения сообщений
    /// </summary>
    public class MessageHub : Hub<IMessageHub>
    {
        private readonly IMessageStorage messageStorage;

        public MessageHub(IMessageStorage messageStorage)
        {
            this.messageStorage = messageStorage;
        }

        /// <summary>
        /// Клиент подсоеденился. Сбрасываем ему старые сообщения
        /// </summary> 
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.ReceiveMessages(messageStorage.GetMessages());
        }
    }
}