using System.Runtime.Serialization;

namespace Pochta.Test.Controllers.Dto
{
    /// <summary>
    /// ДТО сообщения
    /// </summary>
    [DataContract]
    public class MessageDto
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}