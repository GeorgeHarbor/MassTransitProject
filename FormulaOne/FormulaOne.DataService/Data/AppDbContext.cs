using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public virtual DbSet<Driver> Drivers { get; set; }
  public virtual DbSet<Achievement> Achievements { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Achievement>(entity =>
    {
      entity.HasOne(d => d.Driver)
        .WithMany(d => d.Achievements)
        .HasForeignKey(d => d.Driverid)
        .OnDelete(DeleteBehavior.NoAction)
        .HasConstraintName("FK_Achievements_Driver");
    });

  }
}
