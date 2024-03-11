namespace MaswadehEyadSprint4.Data.Entities;

using Microsoft.EntityFrameworkCore;


public class MyApplicationDbContext : DbContext
{
    public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
    { }
    public DbSet<Nutfree> Nutfree { get; set; }
    public DbSet<IcecreamSize> IcecreamSize { get; set; }
    public DbSet<PrimaryFlavours> PrimaryFlavours { get; set; }
    public DbSet<SimpleIcecream> SimpleIcecream { get; set; }
    public DbSet<Specials> Specials { get; set; }
    public DbSet<viewSimpleIcecream> viewSimpleIcecream { get; set; }

}

