using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
        }

        public DbSet<Command> Commands { get; set; }
    }
}
