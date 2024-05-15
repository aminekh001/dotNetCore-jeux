using jeuxVedio.Models;
using Microsoft.EntityFrameworkCore;

namespace jeuxVedio.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<jeuxVedio.Models.Team>? Team { get; set; }

    }
}
