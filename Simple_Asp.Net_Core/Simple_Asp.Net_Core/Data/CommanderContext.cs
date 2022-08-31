using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
        
        }

        protected override void OnModelCreating(ModelBuilder model) { 
        
        }

        public DbSet<Command> Commands { get; set; }
    }
}
