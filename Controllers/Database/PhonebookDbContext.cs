using Microsoft.EntityFrameworkCore;
using Database.Configurations;
using Models;

namespace Database
{
    public class PhonebookDbContext : DbContext
    {
        public DbSet<Phonebook> Phonebooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DotNetEnv.Env.Load();
            optionsBuilder.UseSqlServer(DotNetEnv.Env.GetString("DB_CONNECTION_STRING"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhonebookConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
