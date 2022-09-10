using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.TableConfig;
using Simple_Asp.Net_Core.Models;

namespace Simple_Asp.Net_Core.Model.DBContext
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
            
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfigurationsFromAssembly(typeof(CommandEntiyConfiguration).Assembly);
        }

        public DbSet<Command> Commands { get; set; }

        public DbSet<FTPFile> FTPFiles { get; set; }

        public DbSet<Goods> Goods { get; set; }
    }
}
