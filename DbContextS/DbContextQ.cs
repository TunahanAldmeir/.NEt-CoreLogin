using İnsanKaynaklarıPT.Models;
using Microsoft.EntityFrameworkCore;

namespace İnsanKaynaklarıPT.DbContextS
{
    public class DbContextQ:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Depart> Departs { get; set; }
        public DbSet<Worker>  Workers { get; set; }
        public DbSet<WorkerVacation>  WorkerVacations { get; set; }

        public DbContextQ(DbContextOptions options) : base(options)
        {
		}
	}
}
