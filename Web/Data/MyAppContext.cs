using Microsoft.EntityFrameworkCore;

public class MyAppContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyApp;Trusted_Connection=True;");
    }
}
