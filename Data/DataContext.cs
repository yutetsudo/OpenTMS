using Microsoft.EntityFrameworkCore;

namespace OpenTMS.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Info> Infos { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}
