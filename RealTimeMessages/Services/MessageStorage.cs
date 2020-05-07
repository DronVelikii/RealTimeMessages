using System.Collections.Generic;
using RealTimeMessages.Models;

namespace RealTimeMessages.Services
{
    public class MessageStorage : IMessageStorage
    {
        /// <summary>
        /// Сгенерированные сообщения
        /// </summary>
        private readonly IList<Message> messages = new List<Message>();
        
        public IList<Message> GetMessages()
        {
            return messages;
        }

        public void Add(Message message)
        {
            messages.Add(message);
        }
    }
}