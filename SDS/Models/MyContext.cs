using Microsoft.EntityFrameworkCore;
namespace SDS.Models
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions options):base(options) { }
        public DbSet<Rapport> Rapports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Caisse> Caisses { get; set; }
        public DbSet<ContreBon> ContreBons { get; set; }

    }
}
