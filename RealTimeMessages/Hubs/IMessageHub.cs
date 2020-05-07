using System.Collections.Generic;
using System.Threading.Tasks;
using RealTimeMessages.Models;

namespace RealTimeMessages.Hubs
{
    /// <summary>
    /// Интерфейс хаба сообщений
    /// </summary>
    public interface IMessageHub
    {
        /// <summary>
        /// Получение всех сообщений с сервера
        /// </summary> 
        Task ReceiveMessages(IList<Message> messages);
        
        /// <summary>
        /// Получение нового сообщения
        /// </summary> 
        Task ReceiveMessage(Message message);
    }
}