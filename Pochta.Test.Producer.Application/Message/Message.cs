using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pochta.Test.Producer.Application.Message
{
    /// <summary>
    /// Сообщение 
    /// </summary>
    [Table("Messages")]
    public class Message
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        [Key, Column("IndexNumber"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndexNumber { get; set; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        [Column("Text")]
        public string Text { get; set; }
        
        /// <summary>
        /// Было ли сообщение отправлено в брокер
        /// </summary>
        [Column("IsWasSendedToBroker")]
        public bool IsWasSendedToBroker { get; set; }

        /// <summary>
        /// Для EF
        /// </summary>
        protected Message()
        {
            
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Message(string text)
        {
            Text = text;
        }
    }
}