using AirVinyl.Model;
using System.Data.Entity;

namespace AirVinyl.DataAccessLayer
{
    public class AirVinylDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<VinylRecord> VinylRecords { get; set; }
        public DbSet<RecordStore> RecordStores { get; set; }
        public DbSet<PressingDetail> PressingDetails { get; set; }
    
        public AirVinylDbContext()
        {
            Database.SetInitializer(new AirVinylDBInitializer());
            // disable lazy loading
            Configuration.LazyLoadingEnabled = false;          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ensure the same person can be added to different collections
            // of friends (self-referencing many-to-many relationship)
            modelBuilder.Entity<Person>().HasMany(m => m.Friends).WithMany();

            modelBuilder.Entity<Person>().HasMany(p => p.VinylRecords)
                .WithRequired(r => r.Person).WillCascadeOnDelete(true);
        } 
    }
}
