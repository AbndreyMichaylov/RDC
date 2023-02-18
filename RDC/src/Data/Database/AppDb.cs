using Microsoft.EntityFrameworkCore;
using RDC.src.Data.DataTypes;

namespace RDC.src.Data.Database
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Mouse> Mouses => Set<Mouse>();
    }
}
