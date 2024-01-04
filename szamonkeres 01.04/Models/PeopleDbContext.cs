using Microsoft.EntityFrameworkCore;

namespace szamonkeres_01._04.Models
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Person { get; set; } = null!;
        public DbSet<CreditCard> CreditCard { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=127.0.0.1; database=People; user=root; password=";

                optionsBuilder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            }
        }
    }
}
