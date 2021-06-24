using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pochta.Test.Common;

namespace Pochta.Test.Producer.Data.Message.Implementation
{
    public class MessageContext : DbContext
    {
        private readonly string _sqlConnectionString;

        public DbSet<Application.Message.Message> Messages { get; set; }
        
        public MessageContext(IOptions<AppConfig> config)
        {
            _sqlConnectionString = config.Value.SqlConnectionString;

            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionString);
        }
    }
}