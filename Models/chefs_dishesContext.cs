using chefs_dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjName.Models
{
    public class chefs_dishesContext : DbContext
    {
        public chefs_dishesContext(DbContextOptions options) : base(options) { }

        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<Chef> Chefs { get; set; }

        // public DbSet<Widget> Widgets { get; set; }
        // public DbSet<Item> Items { get; set; }

        public DbSet<Dish> Dishes { get; set; }
    }
}
