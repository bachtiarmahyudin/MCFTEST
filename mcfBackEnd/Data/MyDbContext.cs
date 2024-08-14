using mcfBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace mcfBackEnd.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions) {

            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null) {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables())
                    {
                        databaseCreator.CreateTables();
                        Users.Add(new MsUser()
                        {
                            UserID = 0,
                            UserName = "admin",
                            Password = "admin",
                            IsActive = true,
                        });
                        Locations.Add(new Location() { LocationId = "10001",LocationName = "Jakarta" });
                        Locations.Add(new Location() { LocationId = "10002",LocationName = "Bekasi" });
                        Locations.Add(new Location() { LocationId = "10003",LocationName = "Depok" });
                        Locations.Add(new Location() { LocationId = "10004",LocationName = "Bogor" });
                        Locations.Add(new Location() { LocationId = "10005",LocationName = "Tangerang" });
                        this.SaveChanges();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<MsUser> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BPKB> BPKBs { get; set; }
    }
}
