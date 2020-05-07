using System; 
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using RealTimeMessages.Hubs;
using RealTimeMessages.Models;

namespace RealTimeMessages.Services
{
    /// <summary>
    /// Генератор сообщений
    /// </summary>
    public class MessageProducer : BackgroundService
    {
        private readonly IHubContext<MessageHub, IMessageHub> hub;
        private readonly IMessageStorage messageStorage;

        public MessageProducer(IHubContext<MessageHub, IMessageHub> hub, IMessageStorage messageStorage)
        {
            this.hub = hub;
            this.messageStorage = messageStorage;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = new Message {Text = $"{DateTime.Now}"};
                messageStorage.Add(message);

                await hub.Clients.All.ReceiveMessage(message);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}