using System.Collections.Generic;
using RealTimeMessages.Models;

namespace RealTimeMessages.Services
{
    public interface IMessageStorage
    {
        /// <summary>
        /// Получить все сгенерированные сообщения
        /// </summary> 
        IList<Message> GetMessages();

        /// <summary>
        /// Добавить новое сообщение
        /// </summary> 
        void Add(Message message);
    }
}