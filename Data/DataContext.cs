using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Models;
using OnlineStore.Models.Base;

namespace OnlineStore.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<Product> Product { get; set; }
    public DbSet<ProductType> ProductType { get; set; }
    public DbSet<User> User { get; set; }


    public override int SaveChanges()
    {
      return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void _AddTimestamps()
    {
      var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

      foreach (var entity in entities)
      {
        var now = DateTime.UtcNow;

        if (entity.State == EntityState.Added)
        {
          ((BaseEntity)entity.Entity).CreatedAt = now;
        }
          ((BaseEntity)entity.Entity).UpdatedAt = now;
      }

    }

  }
}