using System;
using Newtonsoft.Json;

namespace Pochta.Test.Common.Transport
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class MessageContainer
    {
        /// <summary>
        /// Порядковый номер сообщения
        /// </summary>
        [JsonProperty("indexNumber")]
        public int IndexNumber { get; set; }

        /// <summary>
        /// Содержание сообщения
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        
        /// <summary>
        /// Дата отправки сообщения, считаем что при инстанцировании объекта - он сразу генерируется времяотправляется
        /// </summary>
        [JsonProperty("sendDateTime")]
        public DateTime SendDateTime { get; set; }

        /// <summary>
        /// Хэш последнего состояния базы
        /// </summary>
        [JsonProperty("previousStorageStateHash")]
        public string PreviousStorageStateHash { get; set; }

        /// <summary>
        /// Конструктор для десереализации
        /// </summary>
        public MessageContainer()
        {
            
        }

        /// <summary>
        /// Конструктор для формирования объекта
        /// </summary>
        /// <param name="indexNumber">Порядковый номер об</param>
        /// <param name="text">Текст сообщения</param>
        /// <param name="previousStorageStateHash">Хэш от последнего состояния БД</param>
        public MessageContainer(int indexNumber, string text, string previousStorageStateHash)
        {
            IndexNumber = indexNumber;
            Text = text;
            SendDateTime = DateTime.UtcNow;
            PreviousStorageStateHash = previousStorageStateHash;
        }
    }
}