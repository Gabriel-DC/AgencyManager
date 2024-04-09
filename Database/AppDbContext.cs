using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }

        public string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "agencyDb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
