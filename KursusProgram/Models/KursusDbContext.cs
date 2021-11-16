using Microsoft.EntityFrameworkCore;

namespace KursusProgram.Models {
    public class KursusDbContext : DbContext {

        public KursusDbContext(DbContextOptions<KursusDbContext> options) : base(options) { }   

        public DbSet<Gantt> Gantts { get; set; }

    }
}
