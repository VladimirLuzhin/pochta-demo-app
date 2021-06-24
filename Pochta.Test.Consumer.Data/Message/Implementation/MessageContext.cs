using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pochta.Test.Common;

namespace Pochta.Test.Consumer.Data.Message.Implementation
{
    /// <summary>
    /// Контекст работы с сообщениями
    /// </summary>
    public class MessageContext : DbContext
    {
        private readonly string _sqlConnectionString;

        /// <summary>
        /// Сообщения
        /// </summary>
        public DbSet<Consumer.Application.Message.Message> Messages { get; set; }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="config"></param>
        public MessageContext(IOptions<AppConfig> config)
        {
            _sqlConnectionString = config.Value.SqlConnectionString;

            Database.EnsureCreated();
        }
        
        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionString);
        }
    }
}