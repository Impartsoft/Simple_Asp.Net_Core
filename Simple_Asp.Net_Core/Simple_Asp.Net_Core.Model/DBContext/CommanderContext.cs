using Microsoft.EntityFrameworkCore;
using Simple_Asp.Net_Core.Model.Models;
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
            optionsBuilder.LogTo(v => Console.WriteLine(v));
        }
            
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfigurationsFromAssembly(typeof(CommandEntiyConfiguration).Assembly);
        }

        public DbSet<Command> Commands { get; set; }

        public DbSet<FTPFile> FTPFiles { get; set; }

        public DbSet<Goods> Goods { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
