using System;

namespace Pochta.Test.Consumer.Application.Message
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Порядковый номер сообщения
        /// </summary>
        public int IndexNumber { get; }

        /// <summary>
        /// Содержание сообщения
        /// </summary>
        public string Text { get; }
        
        /// <summary>
        /// Хэш последнего состояния базы
        /// </summary>
        public string PreviousStorageStateHash { get; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime SendDateTime { get; }

        /// <summary>
        /// Дата получения сообщения
        /// </summary>
        public DateTime ReceiveDateTime { get; } = DateTime.UtcNow;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="indexNumber">Порядковый номер об</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="sendDateTime">Дата отправки сообщения</param>
        /// <param name="previousStorageStateHash">Хэш от последнего состояния БД</param>
        public Message(int indexNumber, string text, DateTime sendDateTime, string previousStorageStateHash)
        {
            IndexNumber = indexNumber;
            Text = text;
            SendDateTime = sendDateTime;
            PreviousStorageStateHash = previousStorageStateHash;
        }
    }
}