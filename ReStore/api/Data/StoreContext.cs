using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<Basket> Baskets { get; set; }

    public DbSet<BasketItem> BasketItem { get; set; }
}
