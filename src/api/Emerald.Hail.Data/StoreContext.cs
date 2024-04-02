using Microsoft.EntityFrameworkCore;
using Emerald.Hail.Domain.Catalog;

namespace Emerald.Hail.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {

    }

    public DbSet<Item> Items { get; set; }
}