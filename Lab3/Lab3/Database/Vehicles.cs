using Microsoft.EntityFrameworkCore;

namespace Lab3.Database;

public class Vehicles : DbContext
{
    public string DbPath { get; set; }

    public Vehicles()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "db.sqlite");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Bike> Bikes { get; set; }

    public List<Vehicle> List
    {
        get
        {
            var list = new List<Vehicle>();
            list.AddRange(Bikes.ToList());
            list.AddRange(Cars.ToList());
            return list;
        }
    }
}