using ClientsAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsAPI.Data
{
    public class TestTaskClientsContext : DbContext
    {
        public TestTaskClientsContext(DbContextOptions<TestTaskClientsContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientWithSpouse> ClientWithSpouses { get; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().Property(p => p.Id).ValueGeneratedNever();
        }
    }
}
